using System;
using System.Collections.Generic;

namespace Data.ValueObject
{
    [Serializable]
    public class FrontYardData
    {
        public List<FrondYardBaseExpend> FrondExpenseDatas;
        public List<FrontYardItemData> frontYardItemDatas;
    }
}