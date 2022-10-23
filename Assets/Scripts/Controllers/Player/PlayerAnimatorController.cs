using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.Controllers.Player
{
    public class PlayerAnimatorController : MonoBehaviour
    {
        [SerializeField] private PlayerManager manager;

        private const string _run = "Run";
        private const string _idle = "Idle";

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayRunAnimation()
        {
            _animator.SetTrigger(_run);
            Debug.Log("run animation called");
        }

        public void PlayIdleAnimation()
        {
            _animator.SetTrigger(_idle);
            Debug.Log("idle animation called");
        }

        public void EnableAimLayer() => _animator.SetLayerWeight(1, 1);

        public void DisableAimLayer() => _animator.SetLayerWeight(1, 0);
    }
}