using States;
using System;
using System.Collections.Generic;

namespace StateMachines
{
    public class StateMachine2
    {
        private IState _currentState;
        private List<Transition> _anyState;

        public void Exacure() => _currentState.Execute();

        public void SetState(IState state)
        {
            if (_currentState == state) return;

            _currentState?.OnExit();
            _currentState = state;
            _currentState?.OnEnter();
        }

        public void AddAnyTransition(Func<bool> condition, IState state) => _anyState.Add(new Transition(condition, state));

        public Transition GetTransition()
        {
            foreach (var transition in _anyState)
            {
                if (transition.Condition()) return transition;
            }

            return null;
        }

        ~StateMachine2()
        {
            _anyState.Clear();
            _currentState = null;
        }
    }

    public class Transition
    {
        public readonly Func<bool> Condition;
        public readonly IState To;

        public Transition(Func<bool> _condition, IState _state)
        {
            Condition = _condition;
            To = _state;
        }
    }
}