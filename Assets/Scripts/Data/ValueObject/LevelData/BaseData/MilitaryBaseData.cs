using System;
using UnityEngine;

namespace Data.ValueObject
{
    [Serializable]
    public class MilitaryBaseData
    {
        public int MaxSoldierAmount;
        public int CandidateAmount;
        public int CurrentSoldierNumber;
        public int SoldierUpgradeTime;
        public int SoldierSlotCostl;
        public int SlouthAmouth;
        public int AttackTime;
        public Transform SlotTransForm;
    }
}