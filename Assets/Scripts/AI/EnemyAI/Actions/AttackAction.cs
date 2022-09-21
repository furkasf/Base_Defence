using Assets.Scripts.Managers;
using FSM;
using Signals;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Must;

namespace Assets.Scripts.AI.EnemyAI.Actions
{
    [CreateAssetMenu(menuName = "FSM/Action/Enemy/AttackAction")]
    public class AttackAction : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            Debug.Log("Enemy in Attack State");
        }
    }
}