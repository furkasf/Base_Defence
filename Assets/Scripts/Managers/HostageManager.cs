using Assets.Scripts.Signals;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class HostageManager : MonoBehaviour
    {
        public bool IsInList;

        [SerializeField] private GameObject Miner;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            HostageSignals.Instance.onActivateMiner += OnActivateMiner;
        }

        private void UnsubscribeEvents()
        {
            HostageSignals.Instance.onActivateMiner -= OnActivateMiner;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion Event Subscription

        public void GoesRunAnimation()
        {
            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Walking"))
            {
                _animator.SetTrigger("Walking");
            }
        }

        public void OnActivateMiner()
        {
            if (IsInList)
            {
                Miner.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}