using Enums;
using System.Collections;
using UnityEngine;

namespace Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_Diamond", menuName = "BaseDefence/Pool/CD_Diamond", order = 0)]
    public class CD_Diamond : CD_AbstractPool<string>
    {
        CD_Diamond()
        {
            Key = PoolAbleType.Diamond.ToString();
            InitialSize = 30;
            IsExtensible = true;
        }
    }
}