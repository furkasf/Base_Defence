using Extentions;
using System;
using UnityEngine;

namespace Assets.Scripts.Signals
{
    public class HostageSignals : MonoSingleton<HostageSignals>
    {
        public Action onLerpStack;
        public Action onClearStack;
        public Action onActivateMiner;
        public Action<Transform> onAddStack;

    }
}