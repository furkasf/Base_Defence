using Assets.Scripts.Managers;
using DG.Tweening;
using Extentions.Grid;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Controllers.Turret
{
    public class TurretAmmoController : MonoBehaviour
    {
        public List<Transform> Ammos = new List<Transform>();

        [SerializeField] TurretManager manager;
        [SerializeField] private GridManager grid;

        public void AddAmmoToGrid(Transform ammo)
        {
            ammo.transform.SetParent(transform);
            ammo.transform.localRotation = Quaternion.Euler(0, 0, 0);
            var position = grid.GetPlacementVector();
            Ammos.Add(ammo.transform);
            ammo.transform.DOMove(position, 1f);
        }

        public void RemoveAmmo()
        {
            Ammos.Remove(Ammos.Last());
            Ammos.TrimExcess();
            grid.ReleaseObjectOnGrid();
        }

        public void GiveAmmoToTurret()
        {
            if(Ammos.Count > 0)
            {
                manager.GetAmmoFromStack();
                RemoveAmmo();
            }
        }

        public int GetAmmoNumber() => Ammos.Count;
    }
}