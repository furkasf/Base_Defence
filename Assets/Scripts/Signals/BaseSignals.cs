using System;
using System.Collections;
using Extentions;
using UnityEngine;

namespace Signals
{
    public class BaseSignals : MonoSingleton<BaseSignals>
    {
        public Func<Vector3> onGetRandomWaypoint;
    }
}