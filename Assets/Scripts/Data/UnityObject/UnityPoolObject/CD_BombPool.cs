using Data.UnityObject;
using Enums;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Data.UnityObject.UnityPoolObject
{
    [CreateAssetMenu(fileName = "CD_BombPool", menuName = "BaseDefence/Pool/CD_BombPool", order = 0)]
    public class CD_BombPool : CD_AbstractPool<string>
    {
        CD_BombPool()
        {
            Key = PoolAbleType.Bomb.ToString();
            InitialSize = 15;
            IsExtensible = true;
        }
    }
}