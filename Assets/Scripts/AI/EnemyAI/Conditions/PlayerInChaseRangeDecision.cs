using Assets.Scripts.Managers;
using Assets.TestScripts;
using FSM;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.AI.EnemyAI.Conditions
{
    [CreateAssetMenu(menuName = "FSM/Decision/Enemy/PlayerInChaseRangeDecision", fileName = "PlayerInChaseRangeDecision")]
    public class PlayerInChaseRangeDecision : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<EnemyManager>();
            if(manager.CheackPlayerFollowAble())
            {
                return true;
            }
            return false;
        }
    }
}