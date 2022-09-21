using FSM;
using Managers;
using UnityEngine;

namespace Assets.Scripts.AI.MinerAi.MinerConditions
{
    [CreateAssetMenu(menuName = "FSM/Decision/Miner/GemIsDelivaredcs")]
    public class GemIsDelivaredcs : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var cheack = stateMachine.GetComponent<MinerManager>();

            return cheack.MinerReachIsTarget();
        }
    }
}