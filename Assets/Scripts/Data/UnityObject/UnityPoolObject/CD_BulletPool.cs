using Data.UnityObject;
using Enums;
using UnityEngine;

namespace Assets.Scripts.Enums.UnityObject.UnityPoolObject
{
    [CreateAssetMenu(fileName = "CD_BulletPool", menuName = "BaseDefence/Pool/CD_BulletPool", order = 0)]
    public class CD_BulletPool : CD_AbstractPool<string>
    {
        CD_BulletPool()
        {
            Key = PoolAbleType.Bullet.ToString();
            InitialSize = 50;
            IsExtensible = true;
        }
    }
   
}