using System;

namespace Data.ValueObject
{
    [Serializable]
    public class FrondYardBaseExpend
    {
        public bool Unclocked;
        public int ExpendCost;
        public int ExpendPayedAmount;
    }
}