using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.SpawnSystem
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private List<AbstractSpawner> abstractSpawners;

        private void Start() => ActivateSpawners();

        public void ActivateSpawners()
        {
            foreach (AbstractSpawner spawner in abstractSpawners)
            {
                StartCoroutine(spawner.Spawn());
            }
        }
    }
}