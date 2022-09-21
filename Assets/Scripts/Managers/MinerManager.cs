using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Managers
{
    public class MinerManager : MonoBehaviour
    {
        public Transform MinePossition;
        public Transform MineDeliveryTarget;
        public bool MineIsEnd;
        public NavMeshAgent Agent;

        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
        }

        public bool MinerReachIsTarget()
        {
            if(Agent.remainingDistance < 0.3f)
            {
                return true;
            }
            return false;
        }

        //wait animdation end and mine
        public IEnumerator MineDiamond()
        {
            Debug.Log("Mining contionue" + Time.deltaTime);
            yield return new WaitForSecondsRealtime(2f);//wait until can use for
            Debug.Log("mineIsEnded");
        }
    }
}