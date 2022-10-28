using Assets.Scripts.Controllers.Turret;
using DG.Tweening;
using Signals;
using Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Managers;

namespace Assets.Scripts.Controllers
{
    public class AmmoSourchController : MonoBehaviour
    {
        private AmmoWorkerManager _ammoWorkerManager;
        private int _defaultAmmoSize = 4;


        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("AmmoWorker"))
            {
                
                AmmoWorkerManager controller = other.GetComponent<AmmoWorkerManager>();
                GetAmmoFromPool(controller);
            }
        }

        private void GetAmmoFromPool(AmmoWorkerManager ammoController)
        {
            for (int i = 0; i < _defaultAmmoSize; i++)
            {
                GameObject obj = PoolSignals.onGetObjectFormPool(PoolAbleType.Ammo.ToString());
                obj.transform.position = transform.position;
                SendAmmosToWorker(ammoController, obj.transform);
            }
        }

        private void SendAmmosToWorker(AmmoWorkerManager pos, Transform ammo) => ammo.DOLocalMove(pos.transform.position, .8f).SetEase(Ease.InQuad).OnComplete(() => pos.AddAmmoToStack(ammo));
    }
}