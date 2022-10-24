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

        [SerializeField] GameObject pistol;
        [SerializeField] private Rigidbody rigidBody;
        [SerializeField] private ShootController shootController;
        [SerializeField] private PlayerMovementController movementController;
        [SerializeField] private PlayerAnimatorController animationController;

        private PlayerData _playerData;
        private bool _isPlayerMoving;

        private void Awake()
        {
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
            PlayerSignals.Instance.onAddEnemyToList += shootController.OnAddEnemyToList;
            PlayerSignals.Instance.onRemoveEnemyToList += shootController.OnRemoveEnemyToList;

            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;

            InputSignals.Instance.onInputTaken += OnPointerDown;
            InputSignals.Instance.onInputReleased += OnInputReleased;
            InputSignals.Instance.onInputDragged += OnInputDragged;
        }

        private void UnsubscribeEvents()
        {
            PlayerSignals.Instance.onGetPlayerState -= OnGetPlayerState;
            PlayerSignals.Instance.onAddEnemyToList -= shootController.OnAddEnemyToList;
            PlayerSignals.Instance.onRemoveEnemyToList -= shootController.OnRemoveEnemyToList;

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
            ActivateMovement();
            animationController.PlayRunAnimation();
            _isPlayerMoving = true;
        }

        private void OnInputReleased()
        {
            DeactivateMovement();
            animationController.PlayIdleAnimation();
            _isPlayerMoving = false;
        }

        private PlayerState OnGetPlayerState() => State;

        public void ActivatePistol(bool activate) => pistol.SetActive(activate);

        public void EnableAimLayer() => animationController.EnableAimLayer();

        public void DisableAimLayer() => animationController.DisableAimLayer();

        private void OnInputDragged(InputParams inputParams) => movementController.UpdateInputValue(inputParams);

        private void ActivateMovement() => movementController.ActivateMovement();

        public void DeactivateMovement() => movementController.DeactivateMovement();

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