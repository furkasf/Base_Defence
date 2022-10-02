using Assets.Scripts.Managers;
using FSM;
using UnityEngine;

namespace Assets.Scripts.AI.EnemyAI.Conditions
{
    [CreateAssetMenu(menuName = "FSM/Decision/Enemy/IsDead")]
    public class IsDeadBase : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<EnemyManager>();
            if (manager.IsDead())
            {
                return true;
            }
            return false;
        }
    }
}