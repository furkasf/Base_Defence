using FSM;
using UnityEngine;

namespace Assets.Scripts.AI.MinerAi.Action
{
    [CreateAssetMenu(menuName = "FSM/Action/Miner/DeliveryGem")]
    public class DeliveryGem : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            Debug.Log("delivert state");
        }
    }
}