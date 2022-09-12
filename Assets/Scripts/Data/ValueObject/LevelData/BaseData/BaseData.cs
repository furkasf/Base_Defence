using System;

namespace Data.ValueObject
{
    [Serializable]
    public class BaseData
    {
        public BaseRoomDatas RoomData;
        public MineBaseData MineData;
        public MilitaryBaseData MilitaryData;
        public BuyablesData BuyablesData;
    }
}