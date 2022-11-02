using Enums;
using Signals;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class BombController : MonoBehaviour
    {
        [SerializeField] ParticleSystem explosion;

        private void OnDisable()
        {
            //explosion.Stop();
        }

        public void PlayBomb() => explosion.Play();

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Ground"))
            {
                explosion.Play();
            }
        }
    }
}