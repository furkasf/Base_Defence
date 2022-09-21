using Assets.Scripts.Managers;
using FSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.AI.EnemyAI.Conditions
{
    [CreateAssetMenu(menuName = "FSM/Decision/Enemy/EnemyAttrackDecision")]
    public class EnemyAttrackDecision : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var attackable = stateMachine.GetComponent<EnemyManager>().IsPlayerAttackable;
            return attackable;
        }
    }
}
