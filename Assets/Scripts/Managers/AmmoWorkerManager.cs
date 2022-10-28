using Assets.Scripts.Controllers.Turret;
using Assets.Scripts.Extentions;
using Assets.Scripts.Signals;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Managers
{
    public class AmmoWorkerManager : MonoBehaviour
    {
        public Transform StackHolder;
        public bool AmmoIsTaken;

        [ShowInInspector] private Transform _ammoStackShop;
        [ShowInInspector] private TurretAmmoController _tarretPool;

        private StackManager _girdStack;
        private NavMeshAgent _agent;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.enabled = false;
            _girdStack = new StackManager(StackHolder.transform, StackType.Money);
        }

        private void Start()
        {
            _agent.enabled = true;
            _ammoStackShop = TurretSignals.Instance.onGetAmmoStackPosition();
            _tarretPool = TurretSignals.Instance.OnGetLowestNumberAmmoTurret();
        }

        #region Actions

        public void GetAmmoFromAmmoShop()
        {
            if (!_agent.hasPath)
            {
                _agent.SetDestination(_ammoStackShop.position);
            }
        }

        public void DeliverAmmosToTurret()
        {
            if (!_agent.hasPath)
            {
                _agent.SetDestination(_tarretPool.transform.position);
            }
        }

        #endregion Actions

        //note : worker doest need to money to get ammos

        #region Conditions

        public bool CheackAmmoIsTaken() => _agent.AgentReachTheTarget();

        public bool CheackAmmoCanDeliveravleToTarret() => _agent.AgentReachTheTarget();

        #endregion Conditions

        #region Utilitys

        public void AddAmmoToStack(Transform obj)//itarate loop 5 times
        {
            _girdStack.AddStack(obj);
        }

        public void RemoveAllAmmoFromStack()
        {
            foreach (var ammo in _girdStack._stack)
            {
                _tarretPool.AddAmmoToGrid(ammo);
            }
            _girdStack._stack.Clear();
            _girdStack.ResetOffsets();
        }

        #endregion Utilitys
    }
}