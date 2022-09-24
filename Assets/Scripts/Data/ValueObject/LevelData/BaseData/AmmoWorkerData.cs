using System;

namespace Data.ValueObject
{
    [Serializable]
    public class AmmoWorkerData
    { 
        public int AmmoWorkerCost = 200;
        public int AmmoWorkerpayedAmount;
        public int AmmoWorkerLevel = 0;
        public int TotalExistMoneyWorker = 0;
        public int MoneyWorkerStackCapacity = 20;
    }
}