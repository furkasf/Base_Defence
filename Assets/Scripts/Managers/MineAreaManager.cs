using Data.ValueObject;
using Signals;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class MineAreaManager : MonoBehaviour
    {
        [SerializeField] private List<Transform> Minepositions;
        [SerializeField] private Transform mineStorage;
        [SerializeField] private Transform mineWagon;

        private MineBaseData data;

        #region subscription
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            MinerBaseSignals.Instance.onGetMineStorage += OnGetMineStorage;
            MinerBaseSignals.Instance.onGetWagon += OnGetWagon;
            MinerBaseSignals.Instance.onGetRandomMine += OnGetRandomMine;
        }

        private void UnsubscribeEvents()
        {

            MinerBaseSignals.Instance.onGetMineStorage -= OnGetMineStorage;
            MinerBaseSignals.Instance.onGetWagon -= OnGetWagon;
            MinerBaseSignals.Instance.onGetRandomMine -= OnGetRandomMine;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        #endregion

        private Transform OnGetMineStorage() => mineStorage;
        private Transform OnGetWagon() => mineWagon;
        private Transform OnGetRandomMine() => Minepositions[Random.Range(0, Minepositions.Count)];
    }
}