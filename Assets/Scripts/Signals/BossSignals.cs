using Extentions;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Signals
{
    public class BossSignals : MonoSingleton<BossSignals>
    {
        public Action<Vector3> OnGetEndPossition;
    }
}