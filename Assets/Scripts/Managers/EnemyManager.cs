using Controllers;
using DG.Tweening;
using Extentions;
using FSM;
using Signals;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Managers
{
    public class EnemyManager : MonoBehaviour
    {
        public Transform PlayerPossition;
        public Transform target;

        public bool IsPlayerAttackable;
        public int Heath = 100;

        [SerializeField] BaseStateMachine ai;
        [SerializeField] EnemyPhysicController physicController;

        private Animator _animator;
        private NavMeshAgent _agent;
        private Renderer _renderer;

        private void Awake()
        {
            PlayerPossition = FindObjectOfType<PlayerManager>().transform;
            _animator = GetComponent<Animator>();
            _renderer = GetComponent<Renderer>();
        }



        public void MoveToTargetPoint()
        {
           if(_agent.speed == _animator.speed)
            {
                _agent.speed = _animator.speed + 3;
                _agent.SetDestination(target.position);
            }
        }

        public void ChaseThePlayer()
        {
            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Walking"))
            {
                _animator.SetTrigger("Walking");
                _agent.speed = _animator.speed;
                _agent.SetDestination(PlayerPossition.position);
            }
        }

        public void AttackTheTarget()
        {
            if(!_animator.GetCurrentAnimatorStateInfo(0).IsName("AttackAnim"))
            {
                _animator.SetTrigger("Attack");
                Debug.Log("attack State");
            }
        }

        public void Dead()
        {
            if(!_animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
            {
                _agent.Stop();
                _animator.SetTrigger("Death");
                _renderer.material.DOFloat(0, "_Saturation", .5f);
            }
        }

        public bool CheackDistanceWithPlayer() => Vector3.Distance(PlayerPossition.position, transform.position) < 10;
        public bool IsDead()
        {
            if(_animator.AnimatorIsPlaying("Death"))
            {
                return false;
            }
            return true;
        }

        //settins for put back to pool
        private void PutToPool()
        {
            _renderer.material.SetFloat("_Saturation", 1);
            PoolSignals.onPutObjectBackToPool(gameObject, "Enemy");
        }

    }
}