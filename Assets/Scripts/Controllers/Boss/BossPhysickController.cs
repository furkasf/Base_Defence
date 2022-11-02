using Assets.Scripts.Managers;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Scripts.Controllers.Boss
{
    public class BossPhysickController : MonoBehaviour
    {
        [SerializeField] BossManager manager;

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Bullet"))
            {
                manager.SetDamage(5);
            }

            if(other.CompareTag("Player"))
            {
                manager.SetTarget(other.transform);
                manager.PlayThrowAnimation();
                print("Player Enter Boss field");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            //if (other.CompareTag("Player"))
            //{
            //    manager.SetTarget(null);
            //    manager.PlayIdleAnimation();
            //}
        }
    }
}