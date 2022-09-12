using System;

namespace Data.ValueObject
{
    [Serializable]
    public class RoomData
    {
        public int RoomCost;
        public int RoomPayedAmouth;
        public TurretData TurretData;
    }
}