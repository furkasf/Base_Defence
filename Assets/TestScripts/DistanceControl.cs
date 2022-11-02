using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.TestScripts
{
    public class DistanceControl : MonoBehaviour
    {
        public List<Vector3> Waypoints;
        public Transform PlayerPossition;

        private void Awake()
        {
            Waypoints.AddRange((IEnumerable<Vector3>)GameObject.FindGameObjectsWithTag("EnemyBaseTarget").Where(x => x.transform));
            PlayerPossition = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public bool CheackDistanceWithPlayer() => Vector3.Distance(PlayerPossition.position, transform.position) < 2; 

        public Vector3 GetRandomPosition() => Waypoints[Random.Range(0, Waypoints.Count)];
    }
}