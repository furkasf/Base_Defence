using Assets.Scripts.Managers;
using FSM;
using UnityEngine;

namespace Assets.Scripts.AI.EnemyAI.Actions
{
    [CreateAssetMenu(menuName = "FSM/Decision/Enemy/PlayerOutofChase", fileName = "PlayerOutofChase")]
    public class PlayerOutofChaseBase : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<EnemyManager>();
            if (!manager.CheackDistanceWithPlayer())
            {
                return true;
            }
            return false;
        }
    }
}