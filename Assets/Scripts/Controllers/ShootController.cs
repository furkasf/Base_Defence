using DG.Tweening;
using Enums;
using Signals;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class ShootController : MonoBehaviour
    {
        public Transform riffle;

        [ShowInInspector] private Transform _currentTarget = null;
        private const float _distance = 15;
        private const float _delay = .3f;
        private float _timer = 0f;

        private void LockTheTarget(Transform target)
        {
            if (target != null)
            {
                Vector3 targetPos = target.transform.position;
                transform.DOLookAt(new Vector3(targetPos.x, transform.position.y, targetPos.z), 0.4f);
                return;
            }
        }

        private void Shoot()
        {
            if (_currentTarget != null)
            {
                var _bullet = PoolSignals.onGetObjectFormPool(PoolAbleType.GunBullet.ToString());
                _bullet.transform.position = riffle.position;
                Vector3 target = new Vector3(_currentTarget.position.x +2, _currentTarget.position.y , _currentTarget.position.z +2) - _bullet.transform.position;
               

                _bullet.transform.DOMove(target, 0.4f).SetRelative().OnComplete(() =>
                {
                    PoolSignals.onPutObjectBackToPool(_bullet, PoolAbleType.GunBullet.ToString());
                });


                _currentTarget = Vector3.Distance(transform.position, _currentTarget.position) <= _distance && _currentTarget != null ? _currentTarget : null;
            }
        }

        public void OnCheackCurrentTargetKilled(Transform enemy)
        {
            if (enemy == _currentTarget)
            {
                _currentTarget = null;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Enemy") && _currentTarget == null)
            {
                _currentTarget = other.transform;
                Debug.Log("enemy in bullet collider");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Enemy") && _currentTarget == other.transform)
            {
                _currentTarget = null;
            }
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer > _delay && _currentTarget != null)
            {
                Shoot();
                _timer = 0;
            }
            LockTheTarget(_currentTarget);
        }
    }
}