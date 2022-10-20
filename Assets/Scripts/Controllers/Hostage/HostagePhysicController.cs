using Assets.Scripts.Managers;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Hostage
{
    public class HostagePhysicController : MonoBehaviour
    {
        [SerializeField] HostageManager manager;

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player") && !manager.IsInList)
            {
                Debug.Log("Player in touch");
                manager.GoesRunAnimation();
            }
        }

    }
}