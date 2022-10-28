using Enums;
using Signals;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Assets.Scripts.SpawnSystem 
{
    public class Spawner : AbstractSpawner
    {

        [SerializeField] PoolAbleType _type;

        public override IEnumerator Spawn()
        {
            var waitForSeconds = new WaitForSeconds(4.5f);

            while (PoolSignals.onGetPoolCurrentSize(_type.ToString()) > 0)
            {
                GameObject _gameObject = PoolSignals.onGetObjectFormPool(_type.ToString());
                _gameObject.transform.position = transform.position;
                yield return waitForSeconds;
            }
        }
    }
}