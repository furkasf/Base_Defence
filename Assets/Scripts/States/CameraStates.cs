using UnityEngine;

namespace States
{
    public class CameraRunnerState : IState
    {
        private Animator _animator;

        public CameraRunnerState(ref Animator animator)
        {
            _animator = animator;
        }

        public void OnEnter() => _animator.SetTrigger("RunnerCam");

        public void OnExit()
        { }

        public void Execute()
        { }
    }

    public class CameraTurretControlState : IState
    {
        private Animator _animator;

        public CameraTurretControlState(ref Animator animator)
        {
            _animator = animator;
        }

        public void OnEnter() => _animator.SetTrigger("TurretCam");

        public void OnExit()
        { }

        public void Execute()
        { }
    }

    public class CameraMiniGameState : IState
    {
        private Animator _animator;

        public CameraMiniGameState(ref Animator animator)
        {
            _animator = animator;
        }

        public void OnEnter() => _animator.SetTrigger("MiniGameCam");

        public void OnExit()
        { }

        public void Execute()
        { }
    }

    public class CameraIdleState : IState
    {
        private Animator _animator;

        public CameraIdleState(ref Animator animator)
        {
            _animator = animator;
        }

        public void OnEnter() => _animator.SetTrigger("IdleCam");

        public void OnExit()
        { }

        public void Execute()
        { }
    }
}