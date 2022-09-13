using Data.UnityObject;
using UnityEngine;

namespace GenericPoolSystem
{
    public class PoolController : MonoBehaviour
    {
        public CD_Pools PoolData;
        private ObjectPoolManager _poolManager;

        private void Awake()
        {
            GetPoolData();
            initializePool();
        }

        private void GetPoolData() => PoolData = Resources.Load<CD_Pools>("Data/CD_Pools");

        public void initializePool()
        {
            _poolManager = new ObjectPoolManager();

            foreach (var pool in PoolData.Pools)
            {
                _poolManager.AddObjectPool(pool.PrefabFactory, pool.ActivatePrefab, pool.DeactivatePrefab, pool.Key, pool.InitialSize, pool.IsExtensible);
            }
        }

        public GameObject GetObjectFormPool(string poolKey)
        {
            return _poolManager.GetObject<GameObject>(poolKey);
        }

        public void PutObjectBackToPool(GameObject gameObject)
        {
            _poolManager.ReturnObject<GameObject>(gameObject);
        }
    }
}