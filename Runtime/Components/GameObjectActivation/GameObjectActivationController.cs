using UUP.CustomAttributes;
using UUP.CustomAttributes.CustomTargets;
using UUP.Extensions;
using UUP.ScriptableObjects.Data.Variables;
using UUP.ScriptableObjects.GameEvents.Serialized;
using UnityEngine;

namespace UUP.Components.GameObjectActivation
{
    public class GameObjectActivationController : MonoBehaviourT
    {
        [SerializeField]
        GameObject GameObject;

        [Tooltip("If true, the GameEvent will be raised according to the Activation State of GameObject")]
        public bool UseGameEvent;
        [ShowIf(nameof(UseGameEvent))]
        public BoolGameEvent ActiveStateGameEvent;

        [Tooltip("If true, the Bool-Variable will change its state according to the Activation State of GameObject")]
        public bool SetBoolVariable;
        [ShowIf(nameof(SetBoolVariable))]
        public BoolVariableSO BoolVariable;

        public bool IsActive => GameObject.activeSelf;

        private void Awake()
        {
            if (GameObject == null)
            {
                Debug.LogError("Missing Reference");
            }
        }

        private void RaiseEventIf()
        {
            if (UseGameEvent)
            {
                if (ActiveStateGameEvent == null)
                {
                    throw new MissingReferenceException("Missing GameEvent Reference");
                }

                ActiveStateGameEvent.Raise(IsActive);
            }
        }

        private void SetVariableIf()
        {
            if (SetBoolVariable)
            {
                if (BoolVariable == null)
                {
                    throw new MissingReferenceException("Missing BoolVariable Reference");
                }

                BoolVariable.Value = IsActive;
            }
        }

        [InspectorButton]
        public void Toggle()
        {
            GameObject.AdaptiveActivation();
            SetVariableIf();
            RaiseEventIf();
        }

        [InspectorButton]
        public void ActivateIfNameEquals(string name)
        {
            if (GameObject.name == name)
            {
                GameObject.SetActive(true);
            }
            else
            {
                GameObject.SetActive(false);
            }
            SetVariableIf();
            RaiseEventIf();
        }

        [InspectorButton]
        public void ActivateIfTagEquals(string tagName)
        {
            if (GameObject.CompareTag(tagName))
            {
                GameObject.SetActive(true);
            }
            else
            {
                GameObject.SetActive(false);
            }
            SetVariableIf();
            RaiseEventIf();
        }

        // Add more methods here
    }
}
