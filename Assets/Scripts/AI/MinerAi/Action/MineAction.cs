﻿using FSM;
using Managers;
using UnityEngine;

namespace Assets.Scripts.AI.MinerAi.Action
{
    [CreateAssetMenu(menuName = "FSM/Action/Miner/MineAction")]
    public class MineAction : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<MinerManager>();

            if (!manager.MineAnimation)
            {
                manager.StartCoroutine(manager.MineDiamond());
            }
            
        }
    }
}