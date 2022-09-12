using System;
using UnityEngine;

namespace Data.ValueObject
{
    [Serializable]
    public class BossPoolData
    {
        public GameObject BossPrefab;
        public int PoolInitialSize = 1;
        public bool IsExtensible = false;
    }
}