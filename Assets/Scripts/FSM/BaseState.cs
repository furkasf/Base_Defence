using System;
using System.CodeDom;
using UnityEngine;

namespace FSM
{
    public abstract class BaseState : ScriptableObject
    {
        public abstract void Execute(BaseStateMachine stateMachine);
    }
}