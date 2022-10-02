﻿using Assets.Scripts.Managers;
using FSM;
using UnityEngine;

namespace Assets.Scripts.AI.EnemyAI.Actions
{
    [CreateAssetMenu(menuName = "FSM/Action/Enemy/MoveTargetAction")]
    public class MoveTargetAction : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<EnemyManager>();
            manager.MoveToTargetPoint();
        }
    }
}