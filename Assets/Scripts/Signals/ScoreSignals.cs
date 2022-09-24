﻿using Data.ValueObject;
using Extentions;
using System;

namespace Assets.Scripts.Signals
{
    public class ScoreSignals : MonoSingleton<ScoreSignals>
    {
        public Action onIncreaseMoney;
        public Action onDecreaseMoney;
        public Action onIncreaseDiamond;
        public Action onDecreaseDiamond;
        public Action onIncreaseLevel;
        public Action onSave;

        public Func<int> onGetLevel;
        public Func<int> onGetMoney;
        public Func<int> onGetDiamond;
        public Func<ScoreData> onGetScoreData;
    }
}