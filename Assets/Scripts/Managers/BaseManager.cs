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
        [SerializeField] List<Transform> targets = new List<Transform>();

        private void Start()
        {
            text.text = "Base " + ScoreSignals.Instance.onGetLevel().ToString();
            Debug.Log("base manager");
        }

        #region subscription
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
           BaseSignals.Instance.OnGetRandomPoint += OnGetRandomPoint;
        }

        private void UnsubscribeEvents()
        {
            BaseSignals.Instance.OnGetRandomPoint -= OnGetRandomPoint;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        #endregion


        private Transform OnGetRandomPoint() => targets[Random.Range(0, targets.Count)];
    }
}