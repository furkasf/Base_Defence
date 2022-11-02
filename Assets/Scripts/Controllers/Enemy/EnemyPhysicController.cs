using Assets.Scripts.Managers;
using Enums;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class EnemyPhysicController : MonoBehaviour
    {
        [SerializeField] private EnemyManager manager;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Bullet"))
            {
                Debug.Log("collidet work");
                manager.GetDamage();
                PoolSignals.onPutObjectBackToPool(other.gameObject, PoolAbleType.Bullet.ToString());
            }

            if (other.CompareTag("Player"))
            {
                manager.IsPLayerFollowAble = true;
                Debug.Log(" player in range");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                manager.IsPLayerFollowAble = false;
            }
        }
    }
}