using Assets.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class EnemyPhysicController : MonoBehaviour
    {
        [SerializeField] EnemyManager manager;

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player") || other.CompareTag("EnemyBaseTarget"))
            {
                //trigger attack state
                manager.IsPlayerAttackable = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") || other.CompareTag("EnemyBaseTarget"))
            {
                //trigger attack state
                manager.IsPlayerAttackable = false;
            }
        }
    }
}