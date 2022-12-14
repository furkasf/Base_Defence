using Signals;
using Cinemachine;
using UnityEngine;


namespace Managers
{
    public class CameraManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public CinemachineStateDrivenCamera StateDrivenCamera { get => _stateDrivenCamera; }
        public Animator StateDrivenCameraAnimator { get => _stateDrivenCameraAnimator; }

        #endregion Public Variables

        #region Private

        private Transform _player;
        private Animator _stateDrivenCameraAnimator;
        private CinemachineStateDrivenCamera _stateDrivenCamera;

        #endregion Private

        #endregion Self Variables

        private void Awake()
        {
            Init();
        }

        #region Subscriptions

        private void OnEnable()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void UnSubscribe()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onReset -= OnReset;
        }

        private void OnDisable()
        {
            UnSubscribe();
        }

        #endregion Subscriptions

        /// <summary>
        /// write action wich taken by camera when Game is Started
        /// </summary>
        private void OnPlay()
        {
        }

       

        private void Init()
        {
            
        }

        /// <summary>
        ///  write action wich taken by camera when Game is Reseted
        /// </summary>
        private void OnReset()
        {
        }
    }
}