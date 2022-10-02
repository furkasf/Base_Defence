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
            if(other.CompareTag("Bullet"))
            {
               //put bullet to pool
               other.gameObject.SetActive(false);
                //call damage funtion from manager
                manager.GetDamage();
            }
           
        }
        
    }
}