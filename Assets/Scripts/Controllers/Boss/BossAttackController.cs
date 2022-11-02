using Assets.Scripts.Managers;
using DG.Tweening;
using Enums;
using Signals;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Boss
{
    public class BossAttackController : MonoBehaviour
    {
        public GameObject targetCircle;

        [SerializeField] private BossManager manager;
        [SerializeField] private float throwTime = 1.5f;
        [SerializeField] private float height = 16;

        private GameObject _grenade;

        public void InitBomb()
        {
            _grenade = PoolSignals.onGetObjectFormPool(PoolAbleType.Bomb.ToString());
            _grenade.SetActive(false);
            _grenade.transform.position = manager.LeftHand.position;
            Debug.Log(_grenade);
        }

        private IEnumerator ThrowBombCoroutine()
        {
            yield return new WaitForSeconds(0.5f);

            targetCircle.transform.DOScale(5, 0.5f).SetEase(Ease.InOutBack);

            if (manager.GetTargetPossition() != null)
            {
                targetCircle.transform.position = manager.GetTargetPossition();


                _grenade.gameObject.SetActive(true);
                _grenade.transform.DOPath(new Vector3[] { new Vector3(( transform.position.x), 20, ( transform.position.z) ),
                new Vector3(targetCircle.transform.position.x, targetCircle.transform.position.y, targetCircle.transform.position.z) }, 1f).OnComplete(() =>
                {
                    PoolSignals.onPutObjectBackToPool(_grenade, PoolAbleType.Bomb.ToString());
                    Debug.Log("bomb sended to pool");
                });
                
                yield return new WaitForSeconds(1f);
                targetCircle.transform.DOScale(0, 0.5f);
                yield return new WaitForSeconds(0.5f);

                ThrowBomb();
            }
        }

        public void ThrowBomb()
        {
            InitBomb();
            transform.LookAt(PlayerSignals.Instance.onGetPlayerTransfrom());
            StopAllCoroutines();
            targetCircle.transform.position = manager.GetTargetPossition();
            StartCoroutine(ThrowBombCoroutine());
        }
    }
}