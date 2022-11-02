using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class MinePhysicController : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                //playerin sinyalinden call
            }
        }

    }
}