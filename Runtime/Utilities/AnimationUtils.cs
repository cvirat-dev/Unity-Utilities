using System.Collections;
using UnityEngine;


namespace UUP.Utilities
{
    /// <summary>
    /// This class may be deprecated because of the newer eventSystem-based approach
    /// </summary>
    public static class AnimationUtils
    {

        /// <summary>
        /// Sets boolean parameter values on an Animator component based on the provided names and values.
        /// This method takes an Animator component, `myAnimator`, an array of string names, `boolNames`, and an array of boolean values, `boolValues`, and sets the boolean parameter values on the Animator based on the provided names and values. 
        /// Each boolean parameter in the Animator is set to the corresponding boolean value from the arrays.
        /// <param name="myAnimator">Animator component</param>
        /// <param name="boolNames">array of string names</param>
        /// <param name="boolValues">array of boolean values</param>
        public static void SetAnimatorValues(Animator myAnimator, string[] boolNames, bool[] boolValues)
        {
            int arrayLength = boolNames.Length;

            for (int i = 0; i < arrayLength; i++)
            {
                myAnimator.SetBool(boolNames[i], boolValues[i]);
            }
        }

        public static void ChangeAnimationState(string newState, ref string currentState, Animator animator)
        {   
            // play the animation
            animator.Play(newState);

            // reassign the current state
            currentState = newState;
        }

        public static void ResetStateToStartAndPlay(string stateToReplay, ref string currentState, Animator animator)
        {
            // play the animation
            animator.Play(stateToReplay, -1, 0f);

            // reassign the current state
            currentState = stateToReplay;
        }

        private static IEnumerator DeactivateAfterDelay(GameObject obj, float delay)
        {
            yield return new WaitForSeconds(delay);
            obj.SetActive(false);
        }
        

    }
}

