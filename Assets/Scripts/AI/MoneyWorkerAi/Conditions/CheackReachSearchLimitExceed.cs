using Assets.Scripts.Managers;
using FSM;
using UnityEngine;

namespace Assets.Scripts.AI.MoneyWorkerAi.Conditions
{
    [CreateAssetMenu(menuName = "FSM/Decision/MoneyWorker/CheackReachSearchLimitExceed", fileName = "CheackReachSearchLimitExceed")]
    public class CheackReachSearchLimitExceed : Decision
    {
        private float _time = 0;

        public override bool Decide(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<MoneyWorkerManager>();

            //to craete time gap between transition to similar states
            _time += Time.smoothDeltaTime;
            if (!manager.CheackMoneyIsTaken())
            {
                if(_time > 1.6f)
                {
                    _time = 0;
                    manager.ResetColliderSize();
                    return true;
                }
               
            }
            return false;
        }
    }
}