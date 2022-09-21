using Signals;
using Enums;
using UnityEngine;
using System;

namespace Managers
{
    public class SpawnManager : MonoBehaviour
    {
        private void Start()
        {
            Invoke("EnemySpawner", 1f);
        }

        //test putpose
        private void EnemySpawner()
        {
            string key = PoolAbleType.Money.ToString();
            if (PoolSignals.onGetPoolCurrentSize(key) <= 0) return;
            GameObject _gameObject = PoolSignals.onGetObjectFormPool(key);
            _gameObject.transform.parent = transform;
            _gameObject.transform.position = transform.position;
        }
        ///intastiate pool item con store in list for deque in when level reseted
        ///

        private void OnDisable()
        {
            //add deque all active pool item
        }
    }
}