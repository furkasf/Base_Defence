using Assets.Scripts.Managers;
using FSM;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.AI.AmmoWorkerAI
{
    [CreateAssetMenu(menuName = "FSM/Action/AmmoWorker/GetAmmoAction", fileName = "GetAmmoAction")]
    public class GetAmmoAction : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<AmmoWorkerManager>();
            manager.GetAmmoFromAmmoShop();
        }
    }
}