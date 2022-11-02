using System;

namespace Data.ValueObject
{
    [Serializable]
    public class MineBaseData
    {
        public int MaxWorkerNumber = 10 ;
        public int CurrentWorkerNumber;
        public int DiamondCapacity = 40;
        public int CurrentDiaMondCapacity;
        public int DiamondCartCapacity = 1;
    }
}