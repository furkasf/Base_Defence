using Assets.Scripts.Managers;
using FSM;
using UnityEngine;

namespace Assets.Scripts.AI.AmmoWorkerAI.Actions
{
    [CreateAssetMenu(menuName = "FSM/Action/AmmoWorker/DeliverAmmoToTurret", fileName = "DeliverAmmoToTurret")]
    public class DeliverAmmoToTurret : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<AmmoWorkerManager>();
            manager.DeliverAmmosToTurret();
        }
    }
}