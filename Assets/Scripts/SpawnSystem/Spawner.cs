using Enums;
using Signals;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Assets.Scripts.SpawnSystem 
{
    public class Spawner : ISpawner
    {

        [SerializeField] PoolAbleType _type;

        public override IEnumerator Spawn()
        {
            var waitForSeconds = new WaitForSeconds(1.5f);

            while (PoolSignals.onGetPoolCurrentSize(_type.ToString()) > 0)
            {
                GameObject _gameObject = PoolSignals.onGetObjectFormPool(_type.ToString());
                _gameObject.transform.parent = transform;
                yield return waitForSeconds;
            }
        }
    }
}