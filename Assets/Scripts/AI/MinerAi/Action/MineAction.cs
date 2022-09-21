using FSM;
using UnityEngine;

namespace Assets.Scripts.AI.MinerAi.Action
{
    [CreateAssetMenu(menuName = "FSM/Action/Miner/MineAction")]
    public class MineAction : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            Debug.Log("mine action");
        }
    }
}