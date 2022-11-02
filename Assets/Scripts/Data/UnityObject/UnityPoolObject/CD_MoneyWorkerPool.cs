using Data.UnityObject;
using Enums;
using UnityEngine;

namespace Assets.Scripts.Enums.UnityObject.UnityPoolObject
{
    [CreateAssetMenu(fileName = "CD_MoneyWorkerPool", menuName = "BaseDefence/Pool/CD_MoneyWorkerPool", order = 0)]
    public class CD_MoneyWorkerPool : CD_AbstractPool<string>
    {
        CD_MoneyWorkerPool()
        {
            Key = PoolAbleType.MoneyWorker.ToString();
            InitialSize = 20;
            IsExtensible = true;
        }
    }
}