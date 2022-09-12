using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Data.ValueObject
{
    public class WorkerPoolData
    {
        public GameObject WorkerPrefab;
        public int PoolInitialSize = 10;
        public bool IsExtensible = false;
    }
}
