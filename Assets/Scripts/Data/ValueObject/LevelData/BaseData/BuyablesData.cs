using System;

namespace Data.ValueObject
{
    [Serializable]
    public class BuyablesData
    {
        public int MoneyWorkerCost;
        public int MoneyWorkerPayedAmount;
        public int AmmoWorkerCost;
        public int AmmoWorkerpayedAmount;
        public int currentMoneyWorkerNumber;
        public int CurrentMoneyWorkerNumber;
        public int MoneyWorkerLevel;
        public int AmmoWorkerLevel;
        public bool available;
    }
}