using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/RemainInState")]
    public sealed class RemainInState : BaseState
    {
        //for stay on current state if codition is true
        public override void Execute(BaseStateMachine stateMachine)
        {
        }
    }
}