using Data.UnityObject;
using Enums;
using UnityEngine;

namespace Assets.Scripts.Enums.UnityObject.UnityPoolObject
{
    [CreateAssetMenu(fileName = "CD_GumAmmoPool", menuName = "BaseDefence/Pool/CD_GumAmmoPool", order = 0)]
    public class CD_GumAmmoPool : CD_AbstractPool<string>
    {
        CD_GumAmmoPool()
        {
            Key = PoolAbleType.GunBullet.ToString();
            InitialSize = 40;
            IsExtensible = true;
        }
    }
}