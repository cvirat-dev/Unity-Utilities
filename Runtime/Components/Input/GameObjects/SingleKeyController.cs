using System.Collections.Generic;
using UnityEngine;
using UUP.Utilities.GameObjectUtils;

namespace UUP.Components.Input.GameObjects
{
    /// <summary>
    /// Compared to the <see cref="MultiKeyController"/> this implementation controls the toggle-state of GameObjects with a single key.
    /// </summary>
    public class SingleKeyController : MonoBehaviour
    {
        [SerializeField, Tooltip("The key that will toggle the GameObjects.")]
        KeyCode InputKey;

        [SerializeField, Tooltip("The GameObjects that will be toggled.")]
        List<GameObject> Objects = new List<GameObject>();

        // Update is called once per frame
        void Update()
        {
            OnInputKeyPressed();
        }

        private void OnInputKeyPressed()
        {
            if(UnityEngine.Input.GetKeyDown(InputKey))
            {
                ListUtils.ToggleActiveGameObject(Objects);
            }
        }
    }
}