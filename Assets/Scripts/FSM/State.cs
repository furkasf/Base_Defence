using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/State")]
    public sealed class State : BaseState
    {
        public List<FSMAction> Actions;
        public List<Transition> Transitions;

        public override void Execute(BaseStateMachine stateMachine)
        {
            foreach (var action in Actions)
                action.Execute(stateMachine);
            foreach (Transition transition in Transitions)
                transition.Execute(stateMachine);
        }
    }
}