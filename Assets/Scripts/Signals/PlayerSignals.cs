using Assets.Scripts.Enums;
using Extentions;
using System;
using UnityEngine;

namespace Signals
{
    public class PlayerSignals : MonoSingleton<PlayerSignals>
    {
        public Action onIsPlayerMoving;
        public Action onGetPlayerTransfrom;
        public Action onGetPlayerSpeed;
        public Func<PlayerState> onGetPlayerState;
        public Action<Transform> onAddEnemyToList;
        public Action<Transform> onRemoveEnemyToList;
    }
}
