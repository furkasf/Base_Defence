using Assets.Scripts.Managers;
using FSM;
using UnityEngine;

namespace Assets.Scripts.AI.AmmoWorkerAI.Conditions
{
    [CreateAssetMenu(menuName = "FSM/Decision/AmmoWorker/CheackWorkerDeliverAmmo", fileName = "CheackWorkerDeliverAmmo")]
    public class CheackWorkerDeliverAmmo : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<AmmoWorkerManager>();
            return manager.CheackAmmoCanDeliveravleToTarret();
        }
    }
}