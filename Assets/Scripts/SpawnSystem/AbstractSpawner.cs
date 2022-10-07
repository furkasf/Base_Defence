using System.Collections;
using UnityEngine;

namespace Assets.Scripts.SpawnSystem
{
    public abstract class AbstractSpawner : MonoBehaviour
    {
        public abstract IEnumerator Spawn();
    }
}