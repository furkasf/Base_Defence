using Assets.Scripts.Extentions;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Managers
{
    public class AmmoWorkerManager : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private Animator _animator;

        //test purpose
        public Transform MoneyPool;

        public Transform TarretPool;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
        }

        #region Actions

       
        public void GetAmmoFromAmmoShop()
        {
           if(!_agent.hasPath)
            {
                _agent.SetDestination(MoneyPool.position);
            }
        }

    
        public void DeliverAmmosToTurret()
        {
            if (!_agent.hasPath)
            {
                _agent.SetDestination(TarretPool.position);
            }
        }

        #endregion Actions

        //note : worker doest need to money to get ammos

        #region Conditions

        public bool CheackAmmoIsTaken() => _agent.AgentReachTheTarget();

        public bool CheackAmmoCanDeliveravleToTarret() => _agent.AgentReachTheTarget();

        #endregion Conditions
    }
}