using Assets.Scripts.Managers;
using FSM;
using UnityEngine;

namespace Assets.Scripts.AI.AmmoWorkerAI.Conditions
{
    [CreateAssetMenu(menuName = "FSM/Decision/AmmoWorker/CheackWorkerRecievAmmo", fileName = "CheackWorkerRecievAmmo")]
    public class CheackWorkerRecievAmmo : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<AmmoWorkerManager>();
           if(manager.CheackAmmoIsTaken())
            {
                manager.RemoveAllAmmoFromStack();
                return true;
            }
            return false;
        }
    }
}