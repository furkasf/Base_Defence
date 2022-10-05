using Assets.Scripts.Managers;
using FSM;
using UnityEngine;

namespace Assets.Scripts.AI.MoneyWorkerAi.Conditions
{
    [CreateAssetMenu(menuName = "FSM/Decision/MoneyWorker/CheackReachTheMoney", fileName = "CheackReachTheMoney")]
    public class CheackReachTheMoney : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<MoneyWorkerManager>();
            if(manager.CheackWorkerReachMoney())
            {
                manager.StackMoney();
                return true;
            }
            return false;
        }
    }
}