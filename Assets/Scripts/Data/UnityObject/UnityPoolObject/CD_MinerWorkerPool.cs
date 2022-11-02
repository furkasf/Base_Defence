using Data.UnityObject;
using Enums;
using UnityEngine;

namespace Assets.Scripts.Enums.UnityObject.UnityPoolObject
{
    [CreateAssetMenu(fileName = "CD_MinerWorkerPool", menuName = "BaseDefence/Pool/CD_MinerWorkerPool", order = 0)]
    public class CD_MinerWorkerPool : CD_AbstractPool<string>
    {
        private CD_MinerWorkerPool()
        {
            Key = PoolAbleType.MinerWorker.ToString();
            InitialSize = 20;
            IsExtensible = true;
        }
    }
}