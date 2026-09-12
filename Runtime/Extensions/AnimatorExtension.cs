using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UUP.Extensions
{
    public static class AnimatorExtension
    {
        /// <summary>
        /// Restarts the animation by playing the given animation clip from the beginning.
        /// </summary>
        /// <param name="animator"></param>
        /// <param name="animationName"></param>
        public static void RestartAnimation(this Animator animator, string animationName)
        {
            animator.Play(animationName, -1, 0f);
        }
    }
}
