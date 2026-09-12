using System.Collections.Generic;
using UnityEngine;
using UUP.Utilities.GameObjectUtils;

namespace UUP.Components.Input.GameObjects
{
    /// <summary>
    /// Combined with the Editor Script <see cref="MultiKeyControllerEditor"/> to create a multi-key controller for GameObjects."/>
    /// </summary>
    public class MultiKeyController : MonoBehaviour
    {
        enum ActivatorTypesEnum
        {
            SingleActivation,
            SimpleActivation
        }

        [SerializeField] List<KeyCode> inputKeys = new List<KeyCode>();
        [SerializeField] List<GameObject> objects = new List<GameObject>();
        
        [SerializeField, Tooltip("SingleActivation :  Only one object can be active at a time. SimpleActivation :  Multiple objects can be active at the same time.")]
        ActivatorTypesEnum activatorTypes;

        public static string InputKeysPropertyName => nameof(inputKeys);
        public static string ObjectsPropertyName => nameof(objects);
        public static string ActivatorTypesPropertyName => nameof(activatorTypes);

        // Update is called once per frame
        void Update()
        {
            ObjectActivationProcessor();
        }

        private void ObjectActivationProcessor()
        {
            for (int i = 0; i < inputKeys.Count; i++)
            {
                if (UnityEngine.Input.GetKeyDown(inputKeys[i]))
                {
                    if(activatorTypes == ActivatorTypesEnum.SingleActivation)
                    {
                        ListUtils.SetActiveObjectFromList(objects, i);
                    }

                    else if(activatorTypes == ActivatorTypesEnum.SimpleActivation)
                    {
                        ListUtils.SimpleToggle(objects[i]);
                    }
                }
            }
        }
    }
}