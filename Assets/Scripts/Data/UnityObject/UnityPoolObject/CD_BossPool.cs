using Enums;
using System;
using UnityEngine;

namespace Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_BossPool", menuName = "BaseDefence/Pool/CD_BossPool", order = 0)]
    public class CD_BossPool : CD_AbstractPool<string>
    {
        private CD_BossPool()
        {
            Key = PoolAbleType.Boss.ToString();
            InitialSize = 1;
            IsExtensible = false;
        }
    }
}