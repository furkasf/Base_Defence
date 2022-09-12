using System;
using UnityEngine;

namespace Data.ValueObject
{
    [Serializable]
    public class PlayerStackData
    {
        [Header("Money Settings")]
        public int MoneyCapacity;

        public Vector2 MoneyOffSet;

        [Space]
        [Header("Ammo Settings")]
        public int AmmoCapacity;

        public Vector2 AmmoOffSet;

        [Space]
        [Header("Hostage Settings")]
        public int HostageCapacity;

        public Vector2 HostageOffSet;
    }
}