using UnityEngine;

namespace FSM
{
    public sealed class Transition : ScriptableObject
    {
        public Decision Decide;
        public BaseState TrueState;
        public BaseState FalseState;

        public void Execute(BaseStateMachine stateMachine)
        {
            if(Decide.Decide(stateMachine) && !(TrueState is RemainInState))
                stateMachine.CurrentState = TrueState;
            else if(!Decide.Decide(stateMachine) && !(FalseState is RemainInState))
                stateMachine.CurrentState = FalseState;
        }
    }
}