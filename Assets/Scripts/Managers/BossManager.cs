using Assets.Scripts.Controllers.Boss;
using DG.Tweening;
using Signals;
using Sirenix.OdinInspector;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class BossManager : MonoBehaviour
    {
        public Transform LeftHand;

        [SerializeField] private GameObject Circle;
        [SerializeField] private Transform bomb;
        [SerializeField] private BossAttackController attackController;
        [SerializeField] private SkinnedMeshRenderer sMeshRenderer;

        [ShowInInspector]private int _health = 500;
        private Animator _animator;
        [SerializeField]private Transform _Player;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetDamage(int damage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                Dead();
            }
        }

        public void Throw() => attackController.ThrowBomb();

        public Vector3 GetTargetPossition() => _Player.position;

        public void SetTarget(Transform target) => _Player = target;

        public void PlayThrowAnimation() => _animator.SetTrigger("Throw");

        public void PlayIdleAnimation() => _animator.SetTrigger("Idle");

        private async void Dead()
        {
            attackController.targetCircle.SetActive(false);
            transform.DOMoveY(-.5f, .2f);
            _animator.SetTrigger("Dead");
            ChangeSaturation(.25f, 1, 1.5f);
            await Task.Delay(2000);
            gameObject.SetActive(false);
        }

        private void ChangeSaturation(float saturation, float brightness, float duration)
        {
            sMeshRenderer.material.DOFloat(saturation, "_Saturation", duration);
            sMeshRenderer.material.DOFloat(brightness, "_Brightness", duration);
        }

    }
}