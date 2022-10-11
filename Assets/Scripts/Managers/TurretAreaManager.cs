using Assets.Scripts.Controllers.Turret;
using Assets.Scripts.Enums;
using Assets.Scripts.Signals;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class TurretAreaManager : MonoBehaviour
    {
        [SerializeField] private List<TurretAmmoController> ammoController;
        [SerializeField] private List<TurretSaveController> saveController;
        [SerializeField] private Transform AmmoStackPosition;
        

        #region Subscriptions

        private void OnEnable()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            TurretSignals.Instance.onGetAmmoStackPosition += OnGetAmmoStackPosition;
            TurretSignals.Instance.onGetTurretAmmoStack += OnGetTurretAmmoStack;
        }

        private void UnSubscribe()
        {
            TurretSignals.Instance.onGetAmmoStackPosition -= OnGetAmmoStackPosition;
            TurretSignals.Instance.onGetTurretAmmoStack -= OnGetTurretAmmoStack;

        }

        private void OnDisable()
        {
            UnSubscribe();
        }

        #endregion Subscriptions

        private Transform OnGetAmmoStackPosition() => AmmoStackPosition;
        private TurretAmmoController OnGetTurretAmmoStack() => ammoController[Random.Range(0, ammoController.Count)];
    }
}