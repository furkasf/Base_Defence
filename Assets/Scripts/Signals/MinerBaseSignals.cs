using System;
using System.Collections;
using Extentions;
using UnityEngine;

namespace Signals
{
    public class MinerBaseSignals : MonoSingleton<MinerBaseSignals>
    {
        public Func<Transform> onGetMineStorage;
        public Func<Transform> onGetWagon;
        public Func<Transform> onGetRandomMine;
        public Action<Transform> onSendDiamondToStack;

    }
}