using Assets.Scripts.Signals;
using Signals;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class BaseManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private List<Transform> targets = new List<Transform>();
        [SerializeField] private Transform baseWayPoint;
        [SerializeField] private Transform outsideBasePoint;

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
            BaseSignals.Instance.OnGetRandomPoint += OnGetRandomPoint;
            BaseSignals.Instance.onGetBaseWayPoint += OnGetBaseWayPoint;
            BaseSignals.Instance.onGetOutSideWayPoint += OnGetOutSideWayPoint;
        }

        private void UnsubscribeEvents()
        {
            BaseSignals.Instance.OnGetRandomPoint -= OnGetRandomPoint;
            BaseSignals.Instance.onGetBaseWayPoint += OnGetBaseWayPoint;
            BaseSignals.Instance.onGetOutSideWayPoint += OnGetOutSideWayPoint;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion subscription

        private Transform OnGetRandomPoint() => targets[Random.Range(0, targets.Count)];
        private Transform OnGetBaseWayPoint() => baseWayPoint;
        private Transform OnGetOutSideWayPoint() => outsideBasePoint;
    }
}