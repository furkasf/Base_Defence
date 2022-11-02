using Assets.Scripts.Managers;
using FSM;
using UnityEngine;

namespace Assets.Scripts.AI.MoneyWorkerAi.Conditions
{
    [CreateAssetMenu(menuName = "FSM/Decision/MoneyWorker/CheackFindMoney", fileName = "CheackFindMoney")]
    public class CheackFindMoney : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<MoneyWorkerManager>();
            if(manager.CheackMoneyIsTaken())
            {
                manager.ResetColliderSize();
                return true;
            }
            return false;
        }
    }
}