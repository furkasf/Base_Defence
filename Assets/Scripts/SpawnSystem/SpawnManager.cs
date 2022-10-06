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
        [SerializeField] private List<ISpawner> abstractSpawners;

        private void Start() => ActivateSpawners();

        public void ActivateSpawners()
        {
            foreach(ISpawner spawner in abstractSpawners)
            {
                StartCoroutine(spawner.Spawn());
            }
        }
    }
}