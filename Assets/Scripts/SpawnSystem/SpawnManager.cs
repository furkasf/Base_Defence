using Signals;
using Enums;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.SpawnSystem
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private List<AbstractSpawner> abstractSpawners;

        private void Start() => ActivateSpawners();

        public void ActivateSpawners()
        {
            foreach(AbstractSpawner spawner in abstractSpawners)
            {
                StartCoroutine(spawner.Spawn());
            }
        }
    }
}