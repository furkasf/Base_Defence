using Assets.Scripts.Controllers.Turret;
using Assets.Scripts.Signals;
using Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class TurretRouterManager : MonoBehaviour
    {

        [SerializeField] private List<TurretAmmoController> ammoControllers;
        [SerializeField] private Transform AmmoStackPosition;


        #region Subscriptions

        private void OnEnable()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            TurretSignals.Instance.OnGetLowestNumberAmmoTurret += OnGetLowestNumberAmmoTurret;
            TurretSignals.Instance.onGetAmmoStackPosition += OnGetAmmoStackPosition;
        }

        private void UnSubscribe()
        {
            TurretSignals.Instance.OnGetLowestNumberAmmoTurret -= OnGetLowestNumberAmmoTurret;
            TurretSignals.Instance.onGetAmmoStackPosition -= OnGetAmmoStackPosition;
        }

        private void OnDisable()
        {
            UnSubscribe();
        }

        #endregion Subscriptions

        public Transform OnGetAmmoStackPosition() => AmmoStackPosition;

        public TurretAmmoController OnGetLowestNumberAmmoTurret()
        {
            TurretAmmoController minimumAmmo = null;
            int ammoCount = 0;
            foreach (var controller in ammoControllers)
            {
                if (controller.GetAmmoNumber() <= ammoCount && controller.gameObject.active)
                {
                    ammoCount = controller.GetAmmoNumber();
                    minimumAmmo = controller;
                }
            }
            return minimumAmmo;
        }    
    }
}