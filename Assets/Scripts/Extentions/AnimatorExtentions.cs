using System;
using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Extentions
{
    public static class AnimatorExtentions
    {
        public static bool AnimatorIsPlaying(this Animator animator, int layer = 0)
        {
            return animator.GetCurrentAnimatorStateInfo(layer).length >
                   animator.GetCurrentAnimatorStateInfo(layer).normalizedTime;
        }

        public static bool AnimatorIsPlaying(this Animator animator, string stateName, int layer =0)
        {
            return (animator.GetCurrentAnimatorStateInfo(layer).length >
                   animator.GetCurrentAnimatorStateInfo(layer).normalizedTime) && animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
        }

        public static IEnumerator CheckAnimationCompleted(this Animator animator ,string CurrentAnim, Action Oncomplete, int layer = 0)
        {
            while (!animator.GetCurrentAnimatorStateInfo(layer).IsName(CurrentAnim))
                yield return null;
            if (Oncomplete != null)
                Oncomplete();
        }
    }
}