using Enums;
using Signals;
using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Test
{
    public class ShotTest : MonoBehaviour
    {
        public List<Transform> Enemys;
        public GameObject bullet;
        public Transform riffle;

        [ShowInInspector] private Transform _currentTarget;
        private const float _distance = 15;
        private const float _delay = 1f;
        private float _timer = 0f;

        private void FindClosestTarget()
        {
            if (_currentTarget != null) return;
            foreach (var enemy in Enemys)
            {
                if (Vector3.Distance(transform.position, enemy.position) <= _distance)
                {
                    _currentTarget = enemy;
                    break;
                }
            }
        }

        private void LockTheTarget(Transform target)
        {
            if(target != null)
            {
                transform.DOLookAt(target.position, 0.4f);
                return;
            }

        }

        private void Shoot()
        {
           
            if (_currentTarget != null)
            {
                
                var _bullet = PoolSignals.onGetObjectFormPool(PoolAbleType.GunBullet.ToString());
                _bullet.transform.position = riffle.position;
                Vector3 target = _currentTarget.position - _bullet.transform.position; // vector macth fucking life saver
                _bullet.transform.DOMove(target, 0.8f).SetRelative().OnComplete(() =>
                {
                    PoolSignals.onPutObjectBackToPool(_bullet, PoolAbleType.GunBullet.ToString());
                });
                _currentTarget = Vector3.Distance(transform.position, _currentTarget.position) <= _distance && _currentTarget != null ? _currentTarget : null;
            }
        }


        private void Update()
        {
            //only work in outside
            _timer += Time.deltaTime;
            if (_timer > _delay)
            {
                FindClosestTarget();
                Shoot();
                _timer = 0;
            }
            LockTheTarget(_currentTarget);
        }
    }
}