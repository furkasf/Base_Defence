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
            EnemySpawner(PoolAbleType.Money.ToString());
        }

        //test putpose
        private void EnemySpawner(string key)
        {
            if (PoolSignals.onGetPoolCurrentSize(key) <= 0) return;
            GameObject _gameObject = PoolSignals.onGetObjectFormPool(key);
            _gameObject.transform.parent = transform;
        }
        ///intastiate pool item con store in list for deque in when level reseted
        ///

        private void OnDisable()
        {
            //add deque all active pool item
        }
    }
}