using Assets.Scripts.Controllers.Turret;
using Assets.Scripts.Extentions;
using Assets.Scripts.Signals;
using Assets.Scripts.Test;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Managers
{
    public class AmmoWorkerManager : MonoBehaviour
    {
        public Transform StackHolder;

        private Transform _ammoStackShop;
        private TurretAmmoController _tarretPool;
        private StackManager _girdStack;
        private NavMeshAgent _agent;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _girdStack = new StackManager(StackHolder.transform);
            Debug.Log(_agent);
        }

        private IEnumerator Start()
        {
            _ammoStackShop = TurretSignals.Instance.onGetAmmoStackPosition();
            _tarretPool = TurretSignals.Instance.onGetTurretAmmoStack();
            yield return null;
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
        }

        #endregion Utilitys
    }
}