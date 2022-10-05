using Assets.Scripts.Managers;
using FSM;
using UnityEngine;

namespace Assets.Scripts.AI.MoneyWorkerAi.Actions
{
    [CreateAssetMenu(menuName = "FSM/Action/MoneyWorker/GotoBaseAction", fileName = "GotoBaseAction")]
    public class GotoBaseAction : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<MoneyWorkerManager>();
            manager.GoToBase();
        }
    }
}