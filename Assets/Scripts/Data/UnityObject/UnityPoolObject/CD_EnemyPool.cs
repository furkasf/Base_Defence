using Enums;
using System.Collections;
using UnityEngine;

namespace Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_EnemyPool", menuName = "BaseDefence/Pool/CD_EnemyPool", order = 0)]
    public class CD_EnemyPool : CD_AbstractPool<string>
    {
        CD_EnemyPool()
        {
            Key = EnemyType.Red.ToString();
            InitialSize = 30;
            IsExtensible = false;
        }
    }
}