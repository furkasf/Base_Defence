using Enums;
using Extentions;
using System;

namespace Signals
{
    public class UISignals : MonoSingleton<UISignals>
    {
        public Action<UIPanels> onOpenPanel;
        public Action<UIPanels> onClosePanel;

        public Action<int> onUpdateStageData;
        public Action<int> onSetLevelText;
    }
}