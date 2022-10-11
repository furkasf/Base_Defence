using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Assets.Scripts.Controllers.Turret
{
    public class TurretAttackController : MonoBehaviour
    {
        private Transform _enemy;
        private Transform _turretRiffle;
        //add ammo count and ammmo data

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Enemy") && _enemy != null)
            {
                AttackTheTarget();
                return;
            }
            if(other.CompareTag("Enemy") && _enemy == null)
            {
                _enemy = other.transform;
                return;
            }
            if(!other.CompareTag("Enemy"))
            {
                _enemy = null;
            }
        }

        private void AttackTheTarget()
        {
            //focus first targer
            //instantiate ammo
            //lookatturret to enemy
            //send bullet
            //if enemy is died remove from stack
        }

    }
}