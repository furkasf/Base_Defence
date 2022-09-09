using StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace States
{
    public class SneakWalkAnimationState : AnimationStateMachine
    {
        public override void ChangeAnimationState()
        {
            _animator.SetTrigger("SneakWalk");
        }
    }

    public class SneakIdleAnimationState : AnimationStateMachine
    {
        public override void ChangeAnimationState()
        {
            _animator.SetTrigger("SneakIdle");
        }
    }

    public class RunnerAnimationState : AnimationStateMachine
    {
        public override void ChangeAnimationState()
        {
            _animator.SetTrigger("Run");
        }
    }

    public class DeathAnimationState : AnimationStateMachine
    {
        public override void ChangeAnimationState()
        {
            _animator.SetTrigger("Death");
        }
    }

    public class IdleAnimationState : AnimationStateMachine
    {
        public override void ChangeAnimationState()
        {
            _animator.SetTrigger("Idle");
        }
    }
}
