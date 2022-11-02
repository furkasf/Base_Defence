using System;
using UnityEngine;

namespace Data.ValueObject
{
    [Serializable]
    public class TurretData
    {
        public bool TurretHasSolder;
        public int TurretWorkerPayedAmouth;
        public int TurretWorkerPrice = 100;
    }
}