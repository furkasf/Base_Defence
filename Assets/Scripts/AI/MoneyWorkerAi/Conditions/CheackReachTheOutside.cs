using Assets.Scripts.Managers;
using FSM;
using UnityEngine;

namespace Assets.Scripts.AI.MoneyWorkerAi.Conditions
{
    [CreateAssetMenu(menuName = "FSM/Decision/MoneyWorker/CheackReachTheOutside", fileName = "CheackReachTheOutside")]
    public class CheackReachTheOutside : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<MoneyWorkerManager>();
            return manager.CheackWorkerReachOutside();
        }
    }
}