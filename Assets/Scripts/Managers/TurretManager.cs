using Assets.Scripts.Controllers.Turret;
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
        }

        private void UnSubscribe()
        {
        }

        private void OnDisable()
        {
            UnSubscribe();
        }

        #endregion Subscriptions

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                TurretAttackController.PlayerInTurret(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                TurretAttackController.PlayerInTurret(false);
            }
        }
        public bool CheackTurretWorkerIsExist() => TurretSaveController.CheackTurretWorkerExist();

        public void LoadAmmo() => TurretAmmoController.LoadAmmo(TurretAttackController.UpdateAmmo);
    }
}