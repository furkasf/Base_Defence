﻿using FSM;
using Managers;
using UnityEngine;

namespace Assets.Scripts.AI.MinerAi.MinerConditions
{
    [CreateAssetMenu(menuName = "FSM/Decision/Miner/MiningIsEnd")]
    public class MiningIsEnd : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<MinerManager>();
            if(manager._isMiningDoneCall)
            {
                manager._isMiningDoneCall = false;
                return true;
            }
            return false;
        }
    }
}