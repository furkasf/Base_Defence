using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Transition")]
    public sealed class Transition : ScriptableObject
    {
        public Decision Decide;
        public BaseState TrueState;
        public BaseState FalseState;

        public void Execute(BaseStateMachine stateMachine)
        {
            if (Decide.Decide(stateMachine) && !(TrueState is RemainInState))
                stateMachine.CurrentState = TrueState;
            else if (!(FalseState is RemainInState))
                stateMachine.CurrentState = FalseState;
        }
    }
}