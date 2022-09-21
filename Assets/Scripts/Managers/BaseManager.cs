using Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class BaseManager : MonoBehaviour
    {
        [SerializeField] private List<Transform> targetWaypoints;

        #region subscription
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            BaseSignals.Instance.onGetRandomWaypoint += OnGetRandomWaypoint;
        }

        private void UnsubscribeEvents()
        {
            BaseSignals.Instance.onGetRandomWaypoint -= OnGetRandomWaypoint;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        #endregion

        public Vector3 OnGetRandomWaypoint() => targetWaypoints[Random.RandomRange(0, targetWaypoints.Count)].position;
    }
}