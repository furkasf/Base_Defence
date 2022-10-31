using Assets.Scripts.Managers;
using Enums;
using Signals;
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
                Debug.Log("collidet work");
                PoolSignals.onPutObjectBackToPool(other.gameObject, PoolAbleType.Bullet.ToString());
                manager.GetDamage();
            }
           
        }
        
    }
}