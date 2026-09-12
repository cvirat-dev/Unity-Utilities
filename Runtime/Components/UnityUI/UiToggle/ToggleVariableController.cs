using UUP.CustomAttributes.CustomTargets;
using UUP.ScriptableObjects.Data.Variables;
using UnityEngine;
using UnityEngine.UI;

namespace UUP.Components.UnityUI.UiToggle
{
    public class ToggleVariableController : MonoBehaviourT
    {
        public BoolVariableSO BoolVariableSO;
        private Toggle _toggle;
        private bool _isListening = false;

        // Start is called before the first frame update
        void Awake()
        {
            // Make sure that the BoolVariable is set to the same value then the UI-Toggle
            _toggle = GetComponent<Toggle>();

            if (_toggle == null)
            {
                Debug.LogError(this + " : Error, the Toggle-Component could not be found on this Gameobject!");
                return;
            }

            _toggle.onValueChanged.AddListener(OnToggleEvent);
            _isListening = true;
        }

        private void OnEnable()
        {
            // No need to check _isListening here since OnEnable should only reattach if necessary
            if (_toggle != null && !_isListening)
            {
                _toggle.onValueChanged.AddListener(OnToggleEvent);
                _isListening = true;
            }
            else
            {
                Debug.LogError("Button component not found on " + gameObject.name);
            }
        }

        private void OnDisable()
        {
            // Ensure listener is removed when the object is disabled
            if (_toggle != null && _isListening)
            {
                _toggle.onValueChanged.RemoveListener(OnToggleEvent);
                _isListening = false;
            }
        }

        private void OnDestroy()
        {
            // Ensure listener is removed when the object is disabled
            if (_toggle != null && _isListening)
            {
                _toggle.onValueChanged.RemoveListener(OnToggleEvent);
                _isListening = false;
            }
        }

        private void OnToggleEvent(bool value)
        {
            BoolVariableSO.Value = value;
        }
    }
}
