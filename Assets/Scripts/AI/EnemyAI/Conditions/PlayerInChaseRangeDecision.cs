using Assets.TestScripts;
using FSM;
using System;
using UnityEngine;

namespace Assets.Scripts.AI.EnemyAI.Conditions
{
    [CreateAssetMenu(menuName = "FSM/Decision/PlayerChaseRengeDesition")]
    public class PlayerInChaseRangeDecision : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var player = stateMachine.GetComponent<DistanceControl>();
            return player.CheackDistanceWithPlayer();
        }
    }
}