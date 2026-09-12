using UnityEngine;
using UUP.Utilities.GameObjectUtils;
using UUP.CustomAttributes.CustomTargets;
using UUP.CustomAttributes;

namespace UUP.Components.GameObjectActivation 
{
    /// <summary>
    /// Utility class to manage an array of GameObjects.
    /// </summary>
    /// <remarks>
    /// Easy to combine with GameEvents which allows Designer-friendly control of GameObjects.
    /// </remarks>
    public class GameObjectsActivationController : MonoBehaviourT
    {
        [SerializeField] 
        GameObject[] GameObjects;

        private void Awake()
        {
            if (GameObjects == null || GameObjects.Length == 0)
            {
                Debug.LogError("The array is empty");
            }
        }

        [InspectorButton]
        public void SetSingleActive(int index)
        {
            ArrayUtils.SetSingleActive(GameObjects, index);
        }

        [InspectorButton]
        public void ToggleSingle(int index)
        {
            ArrayUtils.ToggleSingle(GameObjects, index);
        }

        [InspectorButton]
        public void IterateForwards()
        {
            int actualIndex = ArrayUtils.IndexOfFirstActiveObjectInArray(GameObjects);

            if(actualIndex+1 < GameObjects.Length)
            {
                ArrayUtils.SetSingleActive(GameObjects, actualIndex+1);
            }

            else
            {
                ArrayUtils.SetSingleActive(GameObjects, 0);
            }
        }

        [InspectorButton]
        public void IterateBackwards()
        {
            int actualIndex = ArrayUtils.IndexOfFirstActiveObjectInArray(GameObjects);

            if (actualIndex - 1 >= 0)
            {
                ArrayUtils.SetSingleActive(GameObjects, actualIndex - 1);
            }

            else
            {
                ArrayUtils.SetSingleActive(GameObjects, GameObjects.Length-1);
            }
        }

        [InspectorButton]
        public void ActivateAll()
        {
            ArrayUtils.ActivateAll(GameObjects);
        }

        [InspectorButton]
        public void DeactivateAll()
        {
            ArrayUtils.DeactivateAll(GameObjects);
        }

        [InspectorButton]
        public void ToggleAll()
        {
            ArrayUtils.ToggleAll(GameObjects);
        }

        [InspectorButton]
        public void ActivateByName(string name)
        {
            bool predicate(GameObject obj) => obj.name == name;
            ArrayUtils.ActivateIf(GameObjects, predicate);
        }

        [InspectorButton]
        public void DeactivateByName(string name)
        {
            bool predicate(GameObject obj) => obj.name == name;
            ArrayUtils.DeactivateIf(GameObjects, predicate);
        }

        [InspectorButton]
        public void ActivateByTag(string tag)
        {
            bool predicate(GameObject obj) => obj.CompareTag(tag);
            ArrayUtils.ActivateIf(GameObjects, predicate);
        }

        [InspectorButton]
        public void DeactivateByTag(string tag)
        {
            bool predicate(GameObject obj) => obj.CompareTag(tag);
            ArrayUtils.DeactivateIf(GameObjects, predicate);
        }

        // Add more methods here
    }
}