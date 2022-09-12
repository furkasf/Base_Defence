using System;
using UnityEngine;

namespace Data.ValueObject
{
    [Serializable]
    public class AIStackData
    {
        [Header("Ammo settings")]
        public int MaxAmmoStackCapacity;
        public Vector2 AmmoStackOffSet;

        [Header("Money settings")]
        public int MaxMoneyStackCapacity;
        public Vector2 MoneyStackOffSet;
    }
}