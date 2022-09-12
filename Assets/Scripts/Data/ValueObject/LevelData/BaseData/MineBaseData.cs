using System;

namespace Data.ValueObject
{
    [Serializable]
    public class MineBaseData
    {
        public int MaxWorkerNumber;
        public int CurrentWorkerNumber;
        public int DiamondCapacity;
        public int CurrentDiaMondCapacity;
        public int DiamondCartCapacity;
    }
}