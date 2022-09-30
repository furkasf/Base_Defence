using FSM;
using Managers;
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
            if ((manager.Agent.remainingDistance) <= 2 && manager.Agent.hasPath)
            {
                return true;
            }
            Debug.Log("Miner goes to Mine");
            return false;
        }
    }
}