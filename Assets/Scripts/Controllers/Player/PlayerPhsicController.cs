using Assets.Scripts.Enums;
using Assets.Scripts.Managers;
using Assets.Scripts.Signals;
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
                manager.State = PlayerState.Outside;
                manager.EnableAimLayer();
                manager.ActivatePistol(true);
            }
        }
    }
}