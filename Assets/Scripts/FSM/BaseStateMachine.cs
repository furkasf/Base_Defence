using UnityEngine;

namespace FSM
{
    public class BaseStateMachine : MonoBehaviour
    {
        public BaseState InitialState;
        public BaseState CurrentState;
    }
}