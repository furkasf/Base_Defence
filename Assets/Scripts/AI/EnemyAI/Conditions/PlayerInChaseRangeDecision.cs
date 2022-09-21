using Assets.Scripts.Managers;
using Assets.TestScripts;
using FSM;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.AI.EnemyAI.Conditions
{
    [CreateAssetMenu(menuName = "FSM/Decision/Enemy/PlayerInChaseRangeDecision")]
    public class PlayerInChaseRangeDecision : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var player = stateMachine.GetComponent<EnemyManager>();
            var agent = stateMachine.GetComponent<NavMeshAgent>();
            Debug.Log(player.CheackDistanceWithPlayer());
            return player.CheackDistanceWithPlayer();
        }
    }
}