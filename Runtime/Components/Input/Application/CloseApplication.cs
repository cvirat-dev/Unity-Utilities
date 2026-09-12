using UnityEngine;

namespace UUP.Components.Input
{
    public class CloseApplication : MonoBehaviour
    {
        [SerializeField, Tooltip("Key to close the application")]
        private KeyCode closeKey = KeyCode.Escape;

        void Update()
        {
            if (UnityEngine.Input.GetKeyDown(closeKey))
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
            }
        }
    }
}
