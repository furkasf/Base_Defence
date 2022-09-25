using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;

namespace Managers
{
    public class MinerManager : MonoBehaviour
    {
        public bool MineAnimation { get => _mineAnimationIsDone; }
        public NavMeshAgent Agent { get => _agent; }
        public GameObject Diamond;
        public GameObject PickAxe;


        [SerializeField] Transform MinePossition;
        [SerializeField] Transform MineDeliveryTarget;
      
        private bool _mineAnimationIsDone;
        private bool _gemCarryAnimation;

        private NavMeshAgent _agent;
        private Animator _animator;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
        }


        public void DeliverGemToStack()
        {
            Agent.isStopped = false;
            _animator.SetTrigger("Walking");
            Diamond.SetActive(true);
            transform.LookAt(MineDeliveryTarget);
            _agent.SetDestination(MineDeliveryTarget.position);
        }

        public void GoToMine()
        {
            Diamond.SetActive(false);
            transform.LookAt(MinePossition);
            _animator.SetTrigger("Walking");
            _agent.SetDestination(MinePossition.position);
        }

        public IEnumerator MineDiamond()
        {
            _mineAnimationIsDone = true;
            Debug.Log("mining is happen");
            _agent.SetDestination(MinePossition.position);
            PickAxe.SetActive(true);
            _animator.SetTrigger("Mining");
            yield return new WaitForSecondsRealtime(1.5f);
            _mineAnimationIsDone = false;
            PickAxe.SetActive(false);
        }
    }
}