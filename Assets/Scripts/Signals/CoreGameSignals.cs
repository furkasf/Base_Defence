using Enums;
using Extentions;
using System;

namespace Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        public Action<GameStates> onChangeGameState;

        public Action onLevelInitialize;
        public Action onClearActiveLevel;

        public Action onLevelFailed;
        public Action onLevelSuccessful;
        public Action onNextLevel;
        public Action onRestartLevel;

        public Action onPlay;
        public Action onReset;
    }
}