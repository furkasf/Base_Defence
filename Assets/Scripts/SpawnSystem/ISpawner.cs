using System.Collections;
using UnityEngine;

namespace Assets.Scripts.SpawnSystem
{
    public abstract class ISpawner : MonoBehaviour
    {
        public abstract IEnumerator Spawn();
    }
}