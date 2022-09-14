using Data.UnityObject;
using Signals;
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

        #region Subscriptions

        private void OnEnable()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            PoolSignals.onGetObjectFormPool += OnGetObjectFormPool;
            PoolSignals.onPutObjectBackToPool += OnPutObjectBackToPool;
            PoolSignals.onGetPoolCurrentSize += OnGetPoolCurrentSize;
        }

        private void UnSubscribe()
        {

            PoolSignals.onGetObjectFormPool -= OnGetObjectFormPool;
            PoolSignals.onPutObjectBackToPool -= OnPutObjectBackToPool;
            PoolSignals.onGetPoolCurrentSize -= OnGetPoolCurrentSize;
        }

        private void OnDisable()
        {
            UnSubscribe();
        }

        #endregion Subscriptions

        private void GetPoolData() => PoolData = Resources.Load<CD_Pools>("Data/CD_Pools");

        private void initializePool()
        {
            _poolManager = new ObjectPoolManager();

            foreach (var pool in PoolData.Pools)
            {
                _poolManager.AddObjectPool(pool.PrefabFactory, pool.ActivatePrefab, pool.DeactivatePrefab, pool.Key, pool.InitialSize, pool.IsExtensible);
            }
        }

        private GameObject OnGetObjectFormPool(string poolKey)
        {
            return _poolManager.GetObject<GameObject>(poolKey);
        }

        private void OnPutObjectBackToPool(GameObject gameObject)
        {
            _poolManager.ReturnObject<GameObject>(gameObject);
        }

        private int OnGetPoolCurrentSize(string poolKey)
        {
            return _poolManager.PoolCurrentSize(poolKey);
        }
    }
}