using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace States
{
    public interface IState
    {
        public void OnEnter();
        public void Execute();
        public void OnExit();
    }
}
