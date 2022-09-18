using UnityEngine;

namespace FSM
{
    public abstract class FSMAction : ScriptableObject
    {
        public abstract void Execure(BaseStateMachine stateMachine);
    }
}