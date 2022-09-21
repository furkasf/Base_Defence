using System;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class BaseStateMachine : MonoBehaviour
    {
        public BaseState CurrentState { get; set; }
        [SerializeField] private BaseState _initialState;
        private Dictionary<Type, Component> _cachedComponents;

        private void Awake()
        {
            CurrentState = _initialState;
            _cachedComponents = new Dictionary<Type, Component>();
        }

        private void Update()
        {
            CurrentState.Execute(this);
        }

        public void ResetCurrentState() => CurrentState = _initialState;

        public new T GetComponent<T>() where T : Component
        {
            //if companent allready cached return
            if (_cachedComponents.ContainsKey(typeof(T)))
                return _cachedComponents[typeof(T)] as T;

            var component = base.GetComponent<T>();
            //companent exist but in not dictionary add companent in dictionary and return companent from list
            if (component != null)
            {
                _cachedComponents.Add(typeof(T), component);
            }
            return component;
        }
    }
}