using StateMachine.Camera;

namespace States
{
    public class CameraRunnerState : CameraStateMachine
    {
        public override void ChangeStateCamera()
        {
            _cinamationAnimationStates.Play("RunnerCam");
        }
    }

    public class CameraMiniGameState : CameraStateMachine
    {
        public override void ChangeStateCamera()
        {
            _cinamationAnimationStates.Play("MiniGameCam");
        }
    }

    public class CameraIdleState : CameraStateMachine
    {
        public override void ChangeStateCamera()
        {
            _cinamationAnimationStates.Play("IdleCam");
        }
    }
}
