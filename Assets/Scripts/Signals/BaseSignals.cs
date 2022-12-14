using System;
using System.Collections;
using Assets.Scripts.Controllers.Turret;
using Extentions;
using UnityEngine;

namespace Signals
{
    public class BaseSignals : MonoSingleton<BaseSignals>
    {
        public Func<Transform> OnGetRandomPoint;
        public Func<Transform> onGetBaseWayPoint;
        public Func<Transform> onGetOutSideWayPoint;
        public Func<float> onGetReadius;
    }
}