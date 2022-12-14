using FSM;
using Managers;
using Signals;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace Assets.Scripts.AI.MinerAi.MinerConditions
{
    [CreateAssetMenu(menuName = "FSM/Decision/Miner/MinerDeliverDiamondToStack")]
    public class MinerDeliverDiamondToStackBase : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<MinerManager>();
            if (manager.IsMinerReachDelivaryPoint())
            {
                manager._isMiningDoneCall = false;
                manager.SendDiamondToStack();
                return true;
            }
            Debug.Log("Miner storage goes to Mine");
            return false;
        }
    }
}