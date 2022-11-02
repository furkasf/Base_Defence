using Assets.Scripts.Managers;
using FSM;
using UnityEngine;

namespace Assets.Scripts.AI.MoneyWorkerAi.Actions
{
    [CreateAssetMenu(menuName = "FSM/Action/MoneyWorker/GotoOutsideAction", fileName = "GotoOutsideAction")]
    public class GotoOutsideAction : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<MoneyWorkerManager>();
            manager.GoToOutside();
        }
    }
}