using Enums;
using System.Collections;
using UnityEngine;

namespace Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_MoneyPool", menuName = "BaseDefence/Pool/CD_MoneyPool", order = 0)]
    public class CD_MoneyPool : CD_AbstractPool<string>
    {
        CD_MoneyPool()
        {
            Key = PoolAbleType.Money.ToString();
            InitialSize = 30;
            IsExtensible = true;
        }
    }
}