using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM
{
    public abstract class FSMAction
    {
        public abstract void Execure(BaseStateMachine stateMachine);
    }
}
