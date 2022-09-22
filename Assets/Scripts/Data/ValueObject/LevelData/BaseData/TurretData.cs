using System;
using UnityEngine;

namespace Data.ValueObject
{
    [Serializable]
    public class TurretData
    {
        public bool IsActive;
        public bool TurretHasSolder;
        public int TurretCapacity;
        public int TurretDamage;
        public int TurretAreaPayedAmouth;
        public int TurretAreaPrice = 100;
        
    }
}