using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data.ValueObject
{
    [Serializable]
    public class EnemyPoolData
    {
        public List<GameObject> EnemyPrefab;
        public int InitialSize = 30;
        public bool IsExtendable = false;
    }
}