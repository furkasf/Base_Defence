using Data.UnityObject;
using Enums;
using UnityEngine;

namespace Assets.Scripts.Enums.UnityObject.UnityPoolObject
{
    [CreateAssetMenu(fileName = "CD_AmmoPool", menuName = "BaseDefence/Pool/CD_AmmoPool", order = 0)]
    public class CD_AmmoPool : CD_AbstractPool<string>
    {
        CD_AmmoPool()
        {
            Key = PoolAbleType.Ammo.ToString();
            InitialSize = 25;
            IsExtensible = true;
        }
    }
}