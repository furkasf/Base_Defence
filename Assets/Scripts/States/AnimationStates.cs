using UnityEngine;

namespace States
{
    public class SneakWalkAnimationState : IState
    {
        private Animator _animator;

        public SneakWalkAnimationState(ref Animator animator)
        {
            _animator = animator;
        }

        public void OnEnter() => _animator.SetTrigger("IdleWalk");


        public void OnExit()
        { }

        public void Execute()
        { }
    }

    public class SneakIdleAnimationState : IState
    {
        private Animator _animator;

        public SneakIdleAnimationState(ref Animator animator)
        {
            _animator = animator;
        }

        public void OnEnter() => _animator.SetTrigger("SneakIdle");
        

        public void OnExit()
        { }

        public void Execute()
        { }
    }

    public class RunnerAnimationState : IState
    {
        private Animator _animator;

        public RunnerAnimationState(ref Animator animator)
        {
            _animator = animator;
        }

        public void OnEnter() => _animator.SetTrigger("Runner");


        public void OnExit()
        { }

        public void Execute()
        { }
    }

    public class DeathAnimationState : IState
    {
        private Animator _animator;

        public DeathAnimationState(ref Animator animator)
        {
            _animator = animator;
        }

        public void OnEnter() => _animator.SetTrigger("Death");

        public void OnExit()
        { }

        public void Execute()
        { }
    }

    public class IdleAnimationState : IState
    {
        private Animator _animator;

        public IdleAnimationState(ref Animator animator)
        {
            _animator = animator;
        }

        public void OnEnter() => _animator.SetTrigger("Idle");

        public void OnExit()
        { }

        public void Execute()
        { }
    }
}