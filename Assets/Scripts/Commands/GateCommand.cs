using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Commannds
{
    public class GateCommand : MonoBehaviour
    {
        [SerializeField] Transform gateTransform;

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player") || other.CompareTag("MoneyWorker"))
            {
                gateTransform.transform.DOLocalRotate(new Vector3(0, 0, -90), 0.6f); 
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") || other.CompareTag("MoneyWorker"))
            {
                gateTransform.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.6f);
            }
        }
    }
}
