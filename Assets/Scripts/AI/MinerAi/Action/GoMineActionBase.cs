using FSM;
using Managers;
using UnityEngine;

namespace Assets.Scripts.AI.MinerAi.Action
{
    [CreateAssetMenu(menuName = "FSM/Action/Miner/GoMineAction")]
    public class GoMineActionBase : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<MinerManager>();
            if(!manager.IsMinerReachTheMines())
            {
                Debug.Log("goto mine state active");
                manager.GoToMine();
            }
            
        }
    }
}