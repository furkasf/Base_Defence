using Assets.Scripts.Controllers.Enemy;
using Assets.Scripts.Extentions;
using Assets.Scripts.Signals;
using Controllers;
using Enums;
using Extentions;
using FSM;
using Signals;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Managers
{
    public class EnemyManager : MonoBehaviour
    {
        public Transform PlayerPossition;
        public Transform target;

        public bool IsPLayerFollowAble;
        public bool IsPlayerAttackable;

        public int Heath = 15;

        [SerializeField] private BaseStateMachine stateMachine;
        [SerializeField] private EnemyPhysicController physicController;
        [SerializeField] private EnemyMeshController meshController;

        private Animator _animator;
        private NavMeshAgent _agent;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _agent = GetComponent<NavMeshAgent>();
            _agent.enabled = false;
        }

        private void Start()
        {
            GetReferences();
        }

        public void GetDamage()
        {
            Heath -= 5;
            if (Heath <= 0)
            {
                Dead();
            }
        }

        #region Actions

        public void MoveToTargetPoint()
        {
            if (!_agent.hasPath)
            {
                _animator.SetTrigger("Walking");
                _agent.SetDestination(target.position);
            }
        }

        public void ChaseThePlayer()
        {
            if (!_animator.AnimatorIsPlaying())
            {
                _animator.SetTrigger("Walking");
            }

            Debug.Log("inPlayer Chease state" +
                "");
            _agent.SetDestination(PlayerPossition.position);
        }

        public void AttackTheTarget()
        {
            if (!_animator.AnimatorIsPlaying())
            {
                _animator.SetTrigger("Attack");

                if (PlayerSignals.Instance.onGetPlayerState() == Enums.PlayerState.Outside && Vector3.Distance(transform.position, PlayerPossition.position) < 1.2f)
                {
                    PlayerSignals.Instance.onTakeDamagel(5);
                }

                Debug.Log("attack State");
            }
        }

        public void Dead()
        {
            DropMoney();

            PlayerSignals.Instance.onCheackCurrentTargetKilled(transform);
            stateMachine.enabled = false;
            _agent.isStopped = true;
            _animator.SetTrigger("Death");
            meshController.CloseSaturation();
        }

        #endregion Actions

        #region Conditions

        public bool CheackPlayerFollowAble()
        {
            if (PlayerSignals.Instance.onGetPlayerState() == Enums.PlayerState.Outside)
            {
                return Vector3.Distance(transform.position, PlayerPossition.position) < 5;
            }
            return false;
        }

        public bool CheakTargerAttackAbel()
        {
            if (PlayerSignals.Instance.onGetPlayerState() == Enums.PlayerState.Outside)
            {
                return Vector3.Distance(transform.position, PlayerPossition.position) < .5f;
            }
            return false;
        }

        public bool CheackEnemyReachTheTarget() => _agent.AgentReachTheTarget();

        public bool IsDead() => Heath <= 0;

        #endregion Conditions

        private void GetReferences()
        {
            PlayerPossition = PlayerSignals.Instance.onGetPlayerTransfrom();
            target = BaseSignals.Instance.OnGetRandomPoint();
            _agent.enabled = true;
            stateMachine.enabled = true;
        }

        private void DropMoney()
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject money = PoolSignals.onGetObjectFormPool(PoolAbleType.Money.ToString());
                money.transform.position = transform.position + new Vector3(0, 5, 0);
            }
        }

        #region Reset Object

        //settins for put back to pool
        public void PutToPool()
        {
            Debug.Log("pool worked");
            PlayerSignals.Instance.onCheackCurrentTargetKilled(transform);
            TurretSignals.Instance.onEnemyDead(transform);
            stateMachine.enabled = true;
            Heath = 15;
            meshController.OpenSaturation();
            PoolSignals.onPutObjectBackToPool(gameObject, "Enemy");
        }

        #endregion Reset Object
    }
}