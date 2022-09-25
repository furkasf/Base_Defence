using Assets.Scripts.Signals;
using Data.ValueObject;
using Signals;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class BaseManager : MonoBehaviour
    {
        [SerializeField] TMP_Text text;

        private void Start()
        {
            text.text = "Base " + ScoreSignals.Instance.onGetLevel().ToString();
        }

        #region subscription
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
           
        }

        private void UnsubscribeEvents()
        {
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        #endregion

      

    }
}