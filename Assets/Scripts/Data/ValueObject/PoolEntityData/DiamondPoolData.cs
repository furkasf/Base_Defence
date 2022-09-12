using System;
using UnityEngine;

namespace Data.ValueObject
{
    [Serializable]
    public class DiamondPoolData
    {
        public GameObject DiamondPrefab;
        public int PoolInializeSize = 30;
        public bool IsExtensible;
    }
}