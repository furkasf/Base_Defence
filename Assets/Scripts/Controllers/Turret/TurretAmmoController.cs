using Assets.Scripts.Managers;
using DG.Tweening;
using Enums;
using Extentions.Grid;
using Signals;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Controllers.Turret
{
    public class TurretAmmoController : MonoBehaviour
    {
        public List<Transform> Ammos = new List<Transform>();

        [SerializeField] private TurretManager manager;
        [SerializeField] private GridManager grid;

        public void AddAmmoToGrid(Transform ammo)
        {
            ammo.transform.SetParent(transform);
            ammo.transform.localRotation = Quaternion.Euler(0, 0, 0);
            var position = grid.GetPlacementVector();
            Ammos.Add(ammo.transform);
            ammo.transform.DOMove(position, 1f);
        }

        public void LoadAmmo(Action updateAmmo)
        {
            if (Ammos.Count > 0)
            {
                updateAmmo();
                RemoveAmmo();
            }
        }

        public int GetAmmoNumber() => Ammos.Count;

        private void RemoveAmmo()
        {
            if (Ammos.Count > 0)
            {
                var last = Ammos.Last();
                Ammos.Remove(last);
                Ammos.TrimExcess();
                PoolSignals.onPutObjectBackToPool(last.gameObject, PoolAbleType.Ammo.ToString());
            }
        }
    }
}