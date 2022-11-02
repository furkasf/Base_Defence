using FSM;
using Managers;
using System.Threading;
using UnityEngine;

namespace Assets.Scripts.AI.MinerAi.Action
{
    [CreateAssetMenu(menuName = "FSM/Action/Miner/MineAction")]

    public class MineAction : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<MinerManager>();

            manager.StartCoroutine(manager
                .MineDiamond());
        }
    }
}