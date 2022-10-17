using Assets.Scripts.Controllers.Turret;
using UnityEngine;

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

        public bool CheackTurretWorkerIsExist() => TurretSaveController.CheackTurretWorkerExist();

        public void GiveAmmoToTurrret() => TurretAmmoController.GiveAmmoToTurret();

        public void GetAmmoFromStack() => TurretAttackController.AccesAmmo(1);
    }
}