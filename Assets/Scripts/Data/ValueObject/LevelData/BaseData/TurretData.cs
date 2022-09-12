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
        public ParticleSystem TurretPartical;
    }
}