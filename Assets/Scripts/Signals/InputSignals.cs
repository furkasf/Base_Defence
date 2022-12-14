using Extentions;
using Keys;
using System;

namespace Signals
{
    public class InputSignals : MonoSingleton<InputSignals>
    {
        public Action onEnableInput;
        public Action onDisableInput;
        public Action onFirstTimeTouchTaken;
        public Action onInputTaken;
        public Action<InputParams> onInputDragged;
        public Action onInputReleased;
    }
}