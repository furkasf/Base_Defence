using Data.UnityObject;
using Enums;
using UnityEngine;

namespace Assets.Scripts.Enums.UnityObject.UnityPoolObject
{
    [CreateAssetMenu(fileName = "CD_AmmoWorkerPool", menuName = "BaseDefence/Pool/CD_AmmoWorkerPool", order = 0)]
    public class CD_AmmoWorkerPool : CD_AbstractPool<string>
    {
        CD_AmmoWorkerPool()
        {
            Key = PoolAbleType.AmmoWorker.ToString();
            InitialSize = 20;
            IsExtensible = false;
        }
    }
}