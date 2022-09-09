using System;
using System.Collections.Generic;
using Managers;
using Cinemachine;
using UnityEngine;

namespace StateMachine.Camera
{
    public abstract class CameraStateMachine
    {
        #region Self Variables

        #region Protected Variables

        protected Animator  _cinamationAnimationStates{ get; set; }
       
        #endregion

        #endregion

        public void SetContext(ref Animator cinamationAnimationStates)
        {
            _cinamationAnimationStates = cinamationAnimationStates;
        }

        public abstract void ChangeStateCamera();
    }
}
