using Assets.Scripts.Controllers.Turret;
using Extentions;
using System;
using UnityEngine;

namespace Assets.Scripts.Signals
{
    public class TurretSignals : MonoSingleton<TurretSignals>
    {
        public Func<Transform> onGetAmmoStackPosition;
        public Func<TurretAmmoController> OnGetLowestNumberAmmoTurret;
        public Action<Transform> onEnemyDead;
    }
}