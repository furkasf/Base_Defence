using Assets.Scripts.Managers;
using Assets.Scripts.Signals;
using DG.Tweening;
using Enums;
using Keys;
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

        [SerializeField] private Transform Mizzle;
        [SerializeField] private Transform turretPosition;
        [SerializeField] private TurretManager manager;

        [ShowInInspector] private List<Transform> enemies = new List<Transform>();
        [ShowInInspector] private bool _canShoot;
        private float _delay = 0.1f;
        private float _timer = 0;
        private InputParams _inputParams;
        private bool _canRotateByPlayer;
        public bool _isPlayerUsingTurret = false;

        private void Start()
        {
        }

        #region EventSubscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            TurretSignals.Instance.onEnemyDead += OnEnemyDead;
            InputSignals.Instance.onInputDragged += OnInputDragged;
            InputSignals.Instance.onInputTaken += ActivateRotation;
            InputSignals.Instance.onInputReleased += DeactivateRotation;
            PlayerSignals.Instance.onPlayerEnterTurretArea += OnPlayerUsesTurret;
        }

        private void UnSubscribeEvents()
        {
            TurretSignals.Instance.onEnemyDead -= OnEnemyDead;
            InputSignals.Instance.onInputDragged -= OnInputDragged;
            InputSignals.Instance.onInputTaken -= ActivateRotation;
            InputSignals.Instance.onInputReleased -= DeactivateRotation;
            PlayerSignals.Instance.onPlayerEnterTurretArea -= OnPlayerUsesTurret;

        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion EventSubscription

        private void Update()
        {
            if (!_isPlayerUsingTurret)
            {
                AttackWithWorker();
            }
            else
            {
                PlayerUseTurret();
            }
        }

        public void Fire()
        {
            Transform bullet = GetAmmoFromPool();
            bullet.rotation = Mizzle.rotation;
            bullet.position = Mizzle.position;
            Vector3 enemy = enemies[0].position;
            Vector3 target = enemy - bullet.position;
            bullet.DOMove(target, 0.5f).SetRelative().OnComplete(() => PutAmmoBackToPool(bullet.gameObject));
            AmmoCount--;
        }

        public void AttackWithWorker()
        {
            if (!manager.CheackTurretWorkerIsExist()) return;

            if (_canShoot && enemies.Count > 0)
            {
                float singleStep = Time.deltaTime * 2;
                Vector3 targetDirection = enemies[0].position - turretPosition.position;
                targetDirection.y = 0;
                Vector3 newDirection = Vector3.RotateTowards(turretPosition.forward, targetDirection, singleStep, 0f);
                turretPosition.rotation = Quaternion.LookRotation(newDirection);

                _timer += Time.deltaTime;
                if (_timer > .5f)
                {
                    LoadAmmo();
                    if (enemies.Count == 0) return;
                    if (AmmoCount > 0)
                        Fire();
                    _timer = 0;
                }
            }
        }

        public void PlayerUseTurret()
        {
            _timer += Time.deltaTime;

            if (_timer > .5f)
            {
                LoadAmmo();
                if (AmmoCount > 0 && enemies.Count != 0)
                    Fire();
                _timer = 0;
            }

            if (!_canRotateByPlayer) return;

            if (_inputParams.movementVector.z <= -0.9f)
            {
                _isPlayerUsingTurret = false;
                PlayerSignals.Instance.onPlayerLeaveTurretArea?.Invoke();
            }

            if (_inputParams.movementVector.x < 0.05f)
            {
                turretPosition.rotation = Quaternion.Slerp(turretPosition.rotation, Quaternion.Euler(0, -60, 0), Time.deltaTime);
            }
            else if (_inputParams.movementVector.x > 0.05f)
            {
                turretPosition.rotation = Quaternion.Slerp(turretPosition.rotation, Quaternion.Euler(0, 60, 0), Time.deltaTime);
            }
        }

        private void ActivateRotation() => _canRotateByPlayer = true;

        private void DeactivateRotation() => _canRotateByPlayer = false;

        public void UpdateAmmo() => AmmoCount += AmmoOffset;

        private void OnInputDragged(InputParams inputParams) => _inputParams = inputParams;

        private Transform GetAmmoFromPool() => PoolSignals.onGetObjectFormPool(PoolAbleType.Bullet.ToString()).transform;

        public void PlayerInTurret(bool inUse)
        {
            _isPlayerUsingTurret = inUse;
        }

        private void PutAmmoBackToPool(GameObject ammo) => PoolSignals.onPutObjectBackToPool(ammo, PoolAbleType.Bullet.ToString());

        private void OnEnemyDead(Transform enemy)
        {
            if (enemies.Contains(enemy))
            {
                enemies.Remove(enemy);
                enemies.TrimExcess();
            }
        }

        private void OnPlayerUsesTurret()
        {
            Transform player = PlayerSignals.Instance.onGetPlayerTransfrom();
            player.SetParent(turretPosition);
            player.transform.localPosition = new Vector3(0, 0, -1);
        }

        private void LoadAmmo()
        {
            if (AmmoCount > 0) return;
            manager.LoadAmmo();
        }

        private void OnRemoveTarget(Transform target)
        {
            if (target == enemies[0])
            {
                enemies.RemoveAt(0);
                enemies.TrimExcess();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                enemies.Add(other.transform);
                _canShoot = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                enemies.Remove(other.transform);
                if (enemies.Count == 0) _canShoot = false;
            }
        }
    }
}