using FSM;
using Managers;
using UnityEngine;

namespace Assets.Scripts.AI.MinerAi.Action
{
    [CreateAssetMenu(menuName = "FSM/Action/Miner/DeliveryGem")]
    public class DeliveryGem : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<MinerManager>();
            manager.DeliverGemToStack();
        }
    }

    
}