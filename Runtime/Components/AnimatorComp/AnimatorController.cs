using UUP.Extensions;
using UnityEngine;

namespace UUP.Components.AnimatorComp
{
    public class AnimatorController : MonoBehaviour
    {
        private Animator _animator;
        
        // Start is called before the first frame update
        void Awake()
        {
            _animator = GetComponent<Animator>();

            if (_animator == null)
            {
                Debug.LogError("Animator not found");
                Debug.Break();
            }
        }

        private void OnEnable()
        {
            if (_animator == null)
            {
                _animator = GetComponent<Animator>();

                if ( _animator == null)
                {
                    Debug.LogError("Animator not found");
                    Debug.Break();
                }
            }
        }

        public void RestartAnimation(string animationName)
        {
            _animator.RestartAnimation(animationName);
        }

    }
}