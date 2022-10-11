using Enums;
using Signals;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Managers
{
    public class MinerManager : MonoBehaviour
    {
        public NavMeshAgent Agent { get => _agent; }
        public GameObject Diamond;
        public GameObject PickAxe;
        public bool _isMiningDoneCall;
        public bool _isDeliverGemToStackCall;
        public bool _isMinerReachtoMineCall;

        [SerializeField] private Transform _minerTarget;
        [SerializeField] private Transform _mineDeliveryTarget;

        private NavMeshAgent _agent;
        private Animator _animator;
        private float _timer;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            _agent.speed = _animator.speed;
        }

        private void Start()
        {
            _mineDeliveryTarget = MinerBaseSignals.Instance.onGetMineStorage?.Invoke();
            _minerTarget = MinerBaseSignals.Instance.onGetRandomMine?.Invoke();
        }

        #region Actions

        public void DeliverGemToStack()
        {
            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("CaryGem"))
            {
                _animator.SetTrigger("CaryGem");
                Diamond.SetActive(true);
                PickAxe.SetActive(false);
                transform.LookAt(_mineDeliveryTarget);
                _agent.SetDestination(_mineDeliveryTarget.position);
            }
        }

        public void GoToMine()
        {
            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Walking"))
            {
                Diamond.SetActive(false);
                PickAxe.SetActive(false);
                transform.LookAt(_minerTarget);
                _animator.SetTrigger("Walking");
                _agent.SetDestination(_minerTarget.position);
            }
        }

        public IEnumerator MineDiamond()
        {
            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("MinigAnim"))
            {
                //set timer
                Agent.isStopped = true;
                _animator.SetTrigger("Mining");
                PickAxe.SetActive(true);
                Debug.Log("mining procces");
                yield return new WaitForSecondsRealtime(2);
                Agent.isStopped = false;
                _isMiningDoneCall = true;
            }
        }

        #endregion Actions

        #region Conditions

        public bool IsMinerReachTheMines() => Vector3.Distance(transform.position, _minerTarget.position) <= 2f;

        public bool IsMinerReachDelivaryPoint() => Vector3.Distance(transform.position, _mineDeliveryTarget.position) <= 2f;

        #endregion Conditions

        #region Utality

        public void SendDiamondToStack()
        {
            GameObject _gameObject = PoolSignals.onGetObjectFormPool(PoolAbleType.Diamond.ToString());
            _gameObject.transform.position = Diamond.transform.position;
            MinerBaseSignals.Instance.onSendDiamondToStack(_gameObject.transform);
        }

        #endregion Utality
    }
}