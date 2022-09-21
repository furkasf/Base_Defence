using FSM;
using Signals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.AI.EnemyAI.Actions
{
    [CreateAssetMenu(menuName = "FSM/Action/Enemy/MoveTargetAction")]
    public class MoveTargetAction : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            var agent = stateMachine.GetComponent<NavMeshAgent>();
            if (!agent.hasPath)
            {
                Debug.Log("target added");
                agent.SetDestination(BaseSignals.Instance.onGetRandomWaypoint());
            }
            
        }
    }
}
