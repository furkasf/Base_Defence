using DG.Tweening;
using Extentions.Grid;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers.Turret
{
    public class TurretAmmoController : MonoBehaviour
    {
        //that can be converted into interfave
        [ShowInInspector] private List<Transform> _Ammos = new List<Transform>();
        [SerializeField] private GridManager grid;

        public void AddAmmoToGrid(Transform ammo)
        {
            //Vector3 stockpileScale = transform.localScale;
            //Vector3 scale = new Vector3(1 / stockpileScale.x, 1 / stockpileScale.y, 1 / stockpileScale.z);

            ammo.transform.SetParent(transform);
            //ammo.transform.localScale = scale;
            ammo.transform.localRotation = Quaternion.Euler(0, 0, 0);
            var position = grid.GetPlacementVector();

            _Ammos.Add(ammo.transform);
            ammo.transform.DOMove(position, 1f);
        }
    }
}