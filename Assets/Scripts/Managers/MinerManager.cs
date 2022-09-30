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

        [SerializeField] private Transform MinePossition;
        [SerializeField] private Transform MineDeliveryTarget;

        private NavMeshAgent _agent;
        private Animator _animator;
        private float _timer;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            _agent.speed = _animator.speed;
        }

        #region StateMachine Behaviors

        public void DeliverGemToStack()
        {
            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("CaryGem"))
            {
                _animator.SetTrigger("CaryGem");
                Diamond.SetActive(true);
                PickAxe.SetActive(false);
                transform.LookAt(MineDeliveryTarget);
                _agent.SetDestination(MineDeliveryTarget.position);
            }
        }

        public void GoToMine()
        {
            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Walking"))
            {
                Diamond.SetActive(false);
                PickAxe.SetActive(false);
                transform.LookAt(MinePossition);
                _animator.SetTrigger("Walking");
                _agent.SetDestination(MinePossition.position);
            }
        }

        // public bool MiningIsEnded() => _animator.

        public IEnumerator MineDiamond()
        {
            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("MinigAnim"))
            {
                //set timer
                _animator.SetTrigger("Mining");
                PickAxe.SetActive(true);
                Debug.Log("mining procces");
                yield return new WaitForSecondsRealtime(2);
                Debug.Log("minig is ended");
                _isMiningDoneCall = true;
                yield return null;
            }
        }

        #endregion StateMachine Behaviors

        public bool IsMinerReachTheMines() => Vector3.Distance(transform.position, MinePossition.position) <= 2f;

        public bool IsMinerReachDelivaryPoint() => Vector3.Distance(transform.position, MineDeliveryTarget.position) <= 2f;
    }
}