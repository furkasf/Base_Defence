using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers.Enemy
{
    public class EnemyMeshController : MonoBehaviour
    {
        private Renderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }

        public void OpenSaturation() => _renderer.material.SetFloat("_Saturation", 1);
        public void CloseSaturation() => _renderer.material.DOFloat(0, "_Saturation", .5f);
    }
}