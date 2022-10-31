using Assets.Scripts.Controllers.Turret;
using Assets.Scripts.Enums;
using Assets.Scripts.Managers;
using Assets.Scripts.Signals;
using Signals;
using UnityEngine;

namespace Assets.Scripts.Controllers.Player
{
    public class PlayerPhsicController : MonoBehaviour
    {
        [SerializeField] private PlayerManager manager;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Player enter mine area");
            if (other.CompareTag("Hostage"))
            {
                //HostageSignals.Instance.onAddStack(other.transform);
            }
            if (other.CompareTag("MineArea"))
            {
                Debug.Log("Player enter mine area");
                HostageSignals.Instance.onClearStack();
                HostageSignals.Instance.onActivateMiner();
            }
            if (other.CompareTag("GateInside"))
            {
                Debug.Log("gate inside");
                manager.State = PlayerState.Inside;
                manager.DisableAimLayer();
                manager.ActivatePistol(false);
            }
            if (other.CompareTag("GateOutside"))
            {
                manager.MoneyStackManager.RemoveAllStack();
                manager.State = PlayerState.Outside;
                manager.EnableAimLayer();
                manager.ActivatePistol(true);
            }
            if(other.CompareTag("Money"))
            {
                manager.MoneyStackManager.AddStack(other.transform);
            }
           
            if (other.CompareTag("AmmoHolder"))
            {
                var turretAmmoController = other.GetComponent<TurretAmmoController>();
                manager.AmmoStackManager.RemoveAllStack(turretAmmoController.AddAmmoToGrid);
            }

            if(other.CompareTag("Turret"))
            {
                PlayerSignals.Instance.onPlayerEnterTurretArea();
            }
        }
    }
}