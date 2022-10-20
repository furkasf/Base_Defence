using Assets.Scripts.Commands;
using Assets.Scripts.Signals;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityObject;
using ValueObject;

namespace Assets.Scripts.Managers
{
    public class LerpManager : MonoBehaviour
    {
        [ShowInInspector]private List<Transform> _hostages = new List<Transform>();
        private LerpData _data;
        private LerpCommand _lerpCommand;

        private void Awake()
        {
            GetLerpData();
            _lerpCommand = new LerpCommand(ref _hostages, ref _data, transform);
        }

        private void GetLerpData() => _data = Resources.Load<CD_Lerp>("Data/CD_Lerp").Data;

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            HostageSignals.Instance.onLerpStack += OnLerpStack;
            HostageSignals.Instance.onAddStack += OnAddStack;
            HostageSignals.Instance.onClearStack += OnClearStack;
        }

        private void UnsubscribeEvents()
        {
            HostageSignals.Instance.onLerpStack -= OnLerpStack;
            HostageSignals.Instance.onAddStack -= OnAddStack;
            HostageSignals.Instance.onClearStack -= OnClearStack;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion Event Subscription

        private void OnLerpStack()
        {
            _lerpCommand.Execute();
        }

        private void OnClearStack()
        {
            _hostages.Clear();
            _hostages.TrimExcess();
        }

        private void OnAddStack(Transform hostage)
        {
            if(!_hostages.Contains(hostage))
            {
                _hostages.Add(hostage);
                _hostages.TrimExcess();
            }
        }
    }
}