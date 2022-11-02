using Assets.Scripts.Managers;
using FSM;
using Signals;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Must;

namespace Assets.Scripts.AI.EnemyAI.Actions
{
    [CreateAssetMenu(menuName = "FSM/Action/Enemy/AttackAction" , fileName = "AttackAction")]
    public class AttackAction : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            var manager = stateMachine.GetComponent<EnemyManager>();
            manager.AttackTheTarget();
        }
    }
}