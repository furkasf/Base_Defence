using DG.Tweening;
using Enums;
using Extentions.Grid;
using Signals;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class DianondStackController : MonoBehaviour
    {
        [ShowInInspector] private List<Transform> _gems = new List<Transform>();
        [SerializeField] private GridManager grid;

        public void AddGemToGrid(Transform gem)
        {
            Vector3 stockpileScale = transform.localScale;
            Vector3 scale = new Vector3(1 / stockpileScale.x, 1 / stockpileScale.y, 1 / stockpileScale.z);

            gem.transform.SetParent(transform);
            gem.transform.localScale = scale;
            gem.transform.rotation = Quaternion.Euler(0, 0, 0);
            var position = grid.GetPlacementVector();

            _gems.Add(gem.transform);
            gem.transform.DOMove(position, 1f);
        }

        public void RemoveAllDiamondFromGrid()
        {
            int total = _gems.Count;
            for (int i = 0; i < total; i++)
            {
                var obj = _gems[0];

                obj.transform.DOLocalMove(new Vector3(Random.Range(-2f, 2f), 0.75f, Random.Range(-2f, 2f)), 1f).SetEase(Ease.OutBack);
                obj.transform.DOLocalRotate(Vector3.zero, 0.1f);
                obj.transform.DOLocalMove(new Vector3(0, 0.75f, 0), 0.5f).SetDelay(1f).OnComplete(() =>
                {
                    PoolSignals.onPutObjectBackToPool(obj.gameObject, PoolAbleType.Diamond.ToString());
                });
                grid.ReleaseObjectOnGrid();
                _gems.Remove(obj);
                _gems.TrimExcess();
            }
            grid.ReleaseAllObjectsOnGrid();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                RemoveAllDiamondFromGrid();
            }
        }
    }
}