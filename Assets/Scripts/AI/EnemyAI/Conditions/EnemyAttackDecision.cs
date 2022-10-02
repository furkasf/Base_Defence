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
    public class EnemyAttackDecision : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<EnemyManager>();
            if(manager.CheakTargerAttackAbel())
            {
                return true;
            }
            return false;
        }

    }



}
