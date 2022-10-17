using Assets.Scripts.Controllers.Enemy;
using Assets.Scripts.Signals;
using Controllers;
using Extentions;
using Signals;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Managers
{
    public class EnemyManager : MonoBehaviour
    {
        public Transform PlayerPossition;
        public Transform target;

        public bool IsPlayerAttackable;
        public int Heath = 10;

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
            _agent.enabled = true;
            Debug.Log("enemy manager");
        }

        public void GetDamage()
        {
            Heath -= 5;
            if (Heath <= 0)
            {
                PutToPool();
            }
        }

        #region Actions

        public void MoveToTargetPoint()
        {
            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Walking") || _agent.speed != _animator.speed)
            {
                _agent.speed = _animator.speed;
                _animator.SetTrigger("Walking");
                _agent.SetDestination(target.position);
            }
        }

        public void ChaseThePlayer()
        {
            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Walking") || _agent.speed == _animator.speed)
            {
                _agent.speed = _animator.speed + .5f;
                _animator.SetTrigger("Walking");
                _agent.SetDestination(PlayerPossition.position);
            }
        }

        public void AttackTheTarget()
        {
            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("AttackAnim"))
            {
                _animator.SetTrigger("Attack");
                Debug.Log("attack State");
            }
        }

        public void Dead()
        {
            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
            {
                _agent.isStopped = true;
                _animator.SetTrigger("Death");
                meshController.CloseSaturation();
            }
        }

        #endregion Actions

        #region Conditions

        public bool CheackDistanceWithPlayer() => Vector3.Distance(PlayerPossition.position, transform.position) <= 5;

        public bool CheakTargerAttackAbel() => Vector3.Distance(PlayerPossition.position, transform.position) <= .5f;

        public bool CheackEnemyReachTheTarget() => Vector3.Distance(target.position, transform.position) <= 1.5f;

        public bool IsDead()
        {
            if (_animator.AnimatorIsPlaying("Death"))
            {
                return false;
            }
            return true;
        }

        #endregion Conditions

        private void GetReferences()
        {
            if (PlayerPossition == null)
            {
                PlayerPossition = GameObject.FindGameObjectWithTag("Player").transform;
            }
            target = BaseSignals.Instance.OnGetRandomPoint();
        }

        #region Reset Object

        //settins for put back to pool
        private void PutToPool()
        {
            _agent.isStopped = false;
            Heath = 10;
            meshController.OpenSaturation();
            PoolSignals.onPutObjectBackToPool(gameObject, "Enemy");
        }

        #endregion Reset Object
    }
}