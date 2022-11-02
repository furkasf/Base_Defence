using System;
using System.Collections.Generic;

namespace Data.ValueObject
{
    [Serializable]
    public class LevelData
    {
        public List<BaseData> BaseDatas;
        public List<FrontYardData> FrontYardDatas;
        public List<int> LevelNumber;
    }
}