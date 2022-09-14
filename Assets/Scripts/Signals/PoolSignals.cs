﻿using System;
using System.Collections;
using Extentions;
using Signals;
using UnityEngine;

namespace Signals
{
    public static class PoolSignals
    {
        public static Func<string, GameObject> onGetObjectFormPool;
        public static Func<string, int> onGetPoolCurrentSize;
        public static Action<GameObject> onPutObjectBackToPool;
    }
}