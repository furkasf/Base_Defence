using Assets.Scripts.Managers;
using FSM;
using UnityEngine;

namespace Assets.Scripts.AI.MoneyWorkerAi.Actions
{
    [CreateAssetMenu(menuName = "FSM/Action/MoneyWorker/GotoMoneyAction", fileName = "GotoMoneyAction")]
    public class GotoMoneyAction : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<MoneyWorkerManager>();
            manager.GotoMoney();
        }
    }
}