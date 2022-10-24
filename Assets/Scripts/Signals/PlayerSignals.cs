using Assets.Scripts.Enums;
using Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signals
{
    public class PlayerSignals : MonoSingleton<PlayerSignals>
    {
        public Action onIsPlayerMoving;
        public Action onGetPlayerTransfrom;
        public Action onGetPlayerSpeed;
        public Func<PlayerState> onGetPlayerState;
    }
}
