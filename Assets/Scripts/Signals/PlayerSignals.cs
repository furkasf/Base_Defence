using Assets.Scripts.Enums;
using Extentions;
using System;
using UnityEngine;

namespace Signals
{
    public class PlayerSignals : MonoSingleton<PlayerSignals>
    {
        public Action onIsPlayerMoving;
        public Func<Transform> onGetPlayerTransfrom;
        public Action onGetPlayerSpeed;
        public Action onPlayerEnterTurretArea;
        public Action onPlayerLeaveTurretArea;
        public Action<Transform> onCheackCurrentTargetKilled;
        public Func<PlayerState> onGetPlayerState;
        public Action<Transform> onAddEnemyToList;
        public Action<Transform> onRemoveEnemyToList;
        public Action<Transform> onAddAmmoToPlayer;
    }
}
