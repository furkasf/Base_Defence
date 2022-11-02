using Assets.Scripts.Managers;
using FSM;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.AI.MoneyWorkerAi.Actions
{
    [CreateAssetMenu(menuName = "FSM/Action/MoneyWorker/SearchAction", fileName = "SearchAction")]
    public class SearchAction : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<MoneyWorkerManager>();
            manager.SearchMoney();
        }
    }
}