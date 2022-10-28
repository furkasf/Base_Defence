using Assets.Scripts.Controllers.MoneyWorker;
using Assets.Scripts.Extentions;
using Signals;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Managers
{
    public class MoneyWorkerManager : MonoBehaviour
    {
        public Transform _moneyPosition;

        [SerializeField] private Transform baseLocation;
        [SerializeField] private Transform outsideLocation;
        [SerializeField] private Transform _stackHolder;
        [SerializeField] private MoneyWorkerPhysicController physicController;

        //that long list of data can be converted scriptable object
        private bool _moneyIsTaken;
        private bool _ThereIsNoMoreMoney;
        private NavMeshAgent _agent;
        private SphereCollider _sphereCollider;
        private StackManager _stack;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.enabled = false;
            _sphereCollider = GetComponent<SphereCollider>();
            _stack = new StackManager(_stackHolder, StackType.Money);
        }

        public void Start()
        {
            _agent.enabled = true;
            baseLocation = BaseSignals.Instance.onGetBaseWayPoint();
            outsideLocation = BaseSignals.Instance.onGetOutSideWayPoint();
        }

        #region Actions

        public void GoToBase()
        {
            if (!_agent.hasPath)
            {
                _agent.SetDestination(baseLocation.position);
            }
        }

        public void GoToOutside()
        {
            if (!_agent.hasPath)
            {
                _agent.SetDestination(outsideLocation.position);
            }
        }

        public void SearchMoney() => _sphereCollider.radius = 20f;

        public float GetRadius() => _sphereCollider.radius;

        public void GotoMoney()
        {
            if (!_agent.hasPath)
            {
                _agent.SetDestination(_moneyPosition.position);
            }
        }

        #endregion Actions

        #region Conditions

        public bool CheackMoneyIsTaken() => _moneyPosition != null;

        public bool CheackWorkerReachBase() => _agent.AgentReachTheTarget();

        public bool CheackWorkerReachMoney() => _agent.AgentReachTheTarget();

        public bool CheackWorkerReachOutside() => _agent.AgentReachTheTarget();

        #endregion Conditions

        #region HelperFunctions

        public void ResetColliderSize() => _sphereCollider.radius = 0.5f;

        public void StackMoney()
        {
            _stack.AddStack(_moneyPosition);
            _moneyPosition = null;
        }

        public void RemoveMoneyFromStack() => _stack.RemoveAllStack();

        public void GetExistedMoney(Transform money) => _moneyPosition = money;

        #endregion HelperFunctions

    }
}