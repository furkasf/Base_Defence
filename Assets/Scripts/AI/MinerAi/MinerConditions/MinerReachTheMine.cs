using FSM;
using Managers;
using System;
using UnityEngine;

namespace Assets.Scripts.AI.MinerAi.MinerConditions
{
    [CreateAssetMenu(menuName = "FSM/Decision/Miner/MinerReachTheMine")]
    public class MinerReachTheMine : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<MinerManager>();
            if (manager.IsMinerReachTheMines())
            {
                Debug.Log("Miner Reach The Mine");
                
                return true;
            }
            Debug.Log("Miner goes to Mine");
            return false;
        }
    }

}