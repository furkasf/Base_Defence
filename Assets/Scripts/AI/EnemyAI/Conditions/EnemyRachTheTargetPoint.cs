using Assets.Scripts.Managers;
using FSM;
using UnityEngine;

namespace Assets.Scripts.AI.EnemyAI.Conditions
{
    [CreateAssetMenu(menuName = "FSM/Decision/Enemy/EnemyRachTheTargetPoint", fileName = "EnemyRachTheTargetPoint")]
    public class EnemyRachTheTargetPoint : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<EnemyManager>();
            if (manager.CheackEnemyReachTheTarget())
            {
                return true;
            }
            return false;
        }
    }
}