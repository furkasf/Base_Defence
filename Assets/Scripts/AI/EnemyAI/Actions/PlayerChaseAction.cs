using Assets.Scripts.Managers;
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
    [CreateAssetMenu(menuName = "FSM/Action/Enemy/PlayerChaseAction")]
    public class PlayerChaseAction : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            Debug.Log("player in chese state");
            var player = stateMachine.GetComponent<EnemyManager>();
            var agent = stateMachine.GetComponent<NavMeshAgent>();
            agent.SetDestination(player.PlayerPossition.position);
            
        }
    }
}
