using Assets.Scripts.Managers;
using Assets.Scripts.Signals;
using DG.Tweening;
using Enums;
using Signals;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers.Turret
{
    public class TurretAttackController : MonoBehaviour
    {
        public int AmmoCount;
        public int AmmoOffset = 4;

        [SerializeField] private Transform riffle;
        [SerializeField] private Transform turretPosition;
        [SerializeField] private TurretManager manager;

        private List<Transform> enemies = new List<Transform>();
        private float _delay = 0.3f;
        private float _timer = 0;
        [ShowInInspector] private bool _IsWorkerActive;

        private void Start()
        {
            _IsWorkerActive = manager.CheackTurretWorkerIsExist();
        }

        #region EventSubscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
           // TurretSignals.Instance.onRemoveTarget += OnRemoveTarget;
           //re write the enemy remove signal
        }

        private void UnSubscribeEvents()
        {
            //TurretSignals.Instance.onRemoveTarget -= OnRemoveTarget;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion EventSubscription

        public void AccesAmmo(int ammo) => AmmoCount += AmmoCount * AmmoOffset;

        private Transform GetAmmoFromPool() => PoolSignals.onGetObjectFormPool(PoolAbleType.Bullet.ToString()).transform;

        private void PutAmmoBackToPool(GameObject ammo) => PoolSignals.onPutObjectBackToPool(ammo, PoolAbleType.Bullet.ToString());

        public void LoadTurretWithAmmo() => manager.GiveAmmoToTurrret();

        private void OnRemoveTarget(Transform target)
        {
            if (target == enemies[0])
            {
                enemies.RemoveAt(0);
                enemies.TrimExcess();
            }
        }

        public void Fire()
        {
            Transform bullet = GetAmmoFromPool();
            bullet.position = riffle.position;
            bullet.DOMoveZ(5f, 0.7f).SetRelative().OnComplete(() => PutAmmoBackToPool(bullet.gameObject));
            AmmoCount--;
        }

        public void AttackWithWorker()
        {
            if(AmmoCount == 0)
            {
                LoadTurretWithAmmo();
            }
            if (!_IsWorkerActive && AmmoCount <= 0) return;
            if (enemies.Count > 0)
            {
                float singleStep = Time.deltaTime * 2;
                Vector3 targetDirection = enemies[0].position - turretPosition.transform.position;
                targetDirection.y = 0;
                Vector3 newDirection = Vector3.RotateTowards(turretPosition.transform.forward, targetDirection, singleStep, 0f);
                turretPosition.transform.rotation = Quaternion.LookRotation(newDirection);

                _timer += Time.deltaTime;
                if (_timer > _delay)
                {
                    if (enemies.Count == 0) return;
                    if (AmmoCount > 0)
                        Fire();
                    _timer = 0;
                }
            }
            else
            {
                turretPosition.transform.rotation = Quaternion.Slerp(turretPosition.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 2);
            }
        }
    }
}