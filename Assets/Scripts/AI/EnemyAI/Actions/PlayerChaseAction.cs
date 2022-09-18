using Assets.TestScripts;
using FSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.AI.EnemyAI.Actions
{
    [CreateAssetMenu(menuName = "FSM/Decision/PlayerChaseAction")]
    public class PlayerChaseAction : FSMAction
    {
        public override void Execure(BaseStateMachine stateMachine)
        {
            var agent = stateMachine.GetComponent<NavMeshAgent>();
            var control = stateMachine.GetComponent<DistanceControl>();
            agent.SetDestination(control.GetRandomPosition());
        }
    }
}
