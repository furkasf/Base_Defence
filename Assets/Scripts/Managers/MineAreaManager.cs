using Controllers;
using Data.ValueObject;
using Signals;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class MineAreaManager : MonoBehaviour
    {
        [SerializeField] private List<Transform> Minepositions;
        [SerializeField] private DianondStackController dianondStackController;
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
            MinerBaseSignals.Instance.onSendDiamondToStack += OnSendDiamondToStack;
        }

        private void UnsubscribeEvents()
        {
            MinerBaseSignals.Instance.onGetMineStorage -= OnGetMineStorage;
            MinerBaseSignals.Instance.onGetWagon -= OnGetWagon;
            MinerBaseSignals.Instance.onGetRandomMine -= OnGetRandomMine;
            MinerBaseSignals.Instance.onSendDiamondToStack = OnSendDiamondToStack;

        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion subscription

        private Transform OnGetMineStorage() => mineStorage;

        private Transform OnGetWagon() => mineWagon;

        private Transform OnGetRandomMine() => Minepositions[Random.Range(0, Minepositions.Count)];

        private void OnSendDiamondToStack(Transform gem) => dianondStackController.AddGemToGrid(gem);
    }
}