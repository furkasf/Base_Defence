using Assets.Scripts.Controllers;
using Assets.Scripts.Controllers.Player;
using Assets.Scripts.Enums;
using Controllers;
using Keys;
using Signals;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        public PlayerState State;
        public StackManager MoneyStackManager;
        public StackManager AmmoStackManager;
        public PlayerHealtController HealthController;
        public int Health = 100;

        [SerializeField] GameObject pistol;
        [SerializeField] Transform stackHolder;
        [SerializeField] private Rigidbody rigidBody;
        [SerializeField] private ShootController shootController;
        [SerializeField] private PlayerMovementController movementController;
        [SerializeField] private PlayerAnimatorController animationController;

        private PlayerData _playerData;
        private bool _isPlayerMoving;
        private bool _isPlayerUsingTurret;
        private Transform _parent;

        private void Awake()
        {
            _parent = transform;
            MoneyStackManager = new StackManager(stackHolder, StackType.Money);
            AmmoStackManager = new StackManager(stackHolder, StackType.Ammo);
            State = PlayerState.Inside;
            _playerData = GetPlayerData();
            SetPlayerDataToControllers();
        }

        private PlayerData GetPlayerData() => Resources.Load<CD_Player>("Data/CD_Player").Data;

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            PlayerSignals.Instance.onGetPlayerState += OnGetPlayerState;
            PlayerSignals.Instance.onAddAmmoToPlayer += OnAddAmmoToPlayer;
            PlayerSignals.Instance.onGetPlayerTransfrom += OnGetPlayerTransform;
            PlayerSignals.Instance.onPlayerEnterTurretArea += OnPlayerUseTurret;
            PlayerSignals.Instance.onPlayerLeaveTurretArea += OnPlayerLeaveTurret;
            PlayerSignals.Instance.onCheackCurrentTargetKilled += shootController.OnCheackCurrentTargetKilled;
            PlayerSignals.Instance.onTakeDamagel += OnTakeDamage;

            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;

            InputSignals.Instance.onInputTaken += OnPointerDown;
            InputSignals.Instance.onInputReleased += OnInputReleased;
            InputSignals.Instance.onInputDragged += OnInputDragged;
        }

        private void UnsubscribeEvents()
        {
            PlayerSignals.Instance.onGetPlayerState -= OnGetPlayerState;
            PlayerSignals.Instance.onAddAmmoToPlayer -= OnAddAmmoToPlayer;
            PlayerSignals.Instance.onGetPlayerTransfrom -= OnGetPlayerTransform;
            PlayerSignals.Instance.onPlayerEnterTurretArea -= OnPlayerUseTurret;
            PlayerSignals.Instance.onPlayerLeaveTurretArea -= OnPlayerLeaveTurret;
            PlayerSignals.Instance.onCheackCurrentTargetKilled -= shootController.OnCheackCurrentTargetKilled;
            PlayerSignals.Instance.onTakeDamagel -= OnTakeDamage;


            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onReset -= OnReset;

            InputSignals.Instance.onInputTaken -= OnPointerDown;
            InputSignals.Instance.onInputReleased -= OnInputReleased;
            InputSignals.Instance.onInputDragged -= OnInputDragged;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion Event Subscription

        private bool OnCanBuy() => _isPlayerMoving;

        private void SetPlayerDataToControllers()
        {
            movementController.SetMovementData(_playerData.playerMovementData);
        }

        private void OnPlay()
        {
            movementController.IsReadyToPlay(true);
        }

        private void OnPointerDown()
        {
            if (_isPlayerUsingTurret) return;
            ActivateMovement();
            animationController.PlayRunAnimation();
            _isPlayerMoving = true;
        }

        private void OnInputReleased()
        {
            if (_isPlayerUsingTurret) return;
            DeactivateMovement();
            animationController.PlayIdleAnimation();
            _isPlayerMoving = false;
        }

        private void OnPlayerUseTurret() 
        {
            _isPlayerUsingTurret = true;
            //can activate turrret animation
            DeactivateMovement();
        }

        private void OnPlayerLeaveTurret()//onnec to signal 
        {
            _isPlayerUsingTurret = false;
            transform.SetParent(_parent);
            ActivateMovement();
        }

        private void OnInputDragged(InputParams inputParams)
        {
            if (_isPlayerUsingTurret) return;
            movementController.UpdateInputValue(inputParams);
        }

        private void OnTakeDamage(int damage)
        {
            if (Health >= 0)
            {
                Health -= damage;
            }
            HealthController.SetHealthBar(Health);
        }

        public void UseTurret() => animationController.UseTurret();

        private Transform OnGetPlayerTransfrom() => transform;

        private PlayerState OnGetPlayerState() => State;

        public void ActivatePistol(bool activate) => pistol.SetActive(activate);

        public void PlayRunAnimation() => animationController.PlayRunAnimation();

        public void EnableAimLayer() => animationController.EnableAimLayer();

        public void DisableAimLayer() => animationController.DisableAimLayer();

        private void ActivateMovement() => movementController.ActivateMovement();

        public void DeactivateMovement() => movementController.DeactivateMovement();

        public void OnAddAmmoToPlayer(Transform ammo) => AmmoStackManager.AddStack(ammo);

        private Transform OnGetPlayerTransform() => transform;

        private float OnGetPlayerSpeed() => rigidBody.velocity.magnitude;

        private void OnLevelFailed() => movementController.IsReadyToPlay(false);

        private void OnReset()
        {
            movementController.MovementReset();
            movementController.OnReset();
        }
    }
}