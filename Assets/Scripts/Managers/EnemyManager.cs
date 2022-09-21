using Controllers;
using FSM;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class EnemyManager : MonoBehaviour
    {
        public Transform PlayerPossition;
        public bool IsPlayerAttackable;

        [SerializeField] BaseStateMachine ai;
        [SerializeField] EnemyPhysicController physicController;

        private void Awake()
        {
            PlayerPossition = FindObjectOfType<PlayerManager>().transform;
        }


        public bool CheackDistanceWithPlayer() => Vector3.Distance(PlayerPossition.position, transform.position) < 10;

     
    }
}