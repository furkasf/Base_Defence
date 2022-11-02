using Assets.Scripts.Controllers.Turret;
using Assets.Scripts.Signals;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Assets.Scripts.Managers
{
    public class TurretManager : MonoBehaviour
    {
        public TurretAmmoController TurretAmmoController;
        public TurretSaveController TurretSaveController;
        public TurretAttackController TurretAttackController;

        #region Subscriptions

        private void OnEnable()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            TurretSignals.Instance.onCheackTurretWorkerIsExist += OnCheackTurretWorkerIsExist;
        }

        private void UnSubscribe()
        {
            TurretSignals.Instance.onCheackTurretWorkerIsExist -= OnCheackTurretWorkerIsExist;

        }

        private void OnDisable()
        {
            UnSubscribe();
        }

        #endregion Subscriptions

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !OnCheackTurretWorkerIsExist())
            {
                TurretAttackController.PlayerInTurret(true);
            }
        }

      
        public bool OnCheackTurretWorkerIsExist() => TurretSaveController.CheackTurretWorkerExist();

        public void LoadAmmo() => TurretAmmoController.LoadAmmo(TurretAttackController.UpdateAmmo);
    }
}