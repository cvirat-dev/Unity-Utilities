using UUP.CustomAttributes;
using UUP.CustomAttributes.CustomTargets;
using UUP.ScriptableObjects.GameEvents;
using UnityEngine;
using UnityEngine.UI;

namespace UUP.Components.UnityUI.UiButton
{
    public class ButtonEventController : MonoBehaviourT
    {
        Button _button;
        bool _isListening = false;
        [SerializeField] GameEvent OnButtonClickGE;

        private void Awake()
        {
            _button = GetComponent<Button>();

            if (_button == null)
            {
                Debug.LogError("Button component not found on " + gameObject.name);
                //_button = gameObject.AddComponent<Button>();
                return;
            }

            _button.onClick.AddListener(OnButtonClick);
            _isListening = true;
        }

        private void OnEnable()
        {
            if (_button == null)
            {
                Debug.LogError("Button component not found on " + gameObject.name);
                //_button = gameObject.AddComponent<Button>();
                return;
            }

            if (!_isListening)
            {
                _button.onClick.AddListener(OnButtonClick);
                _isListening = true;
            }
        }

        private void OnDisable()
        {
            // Ensure listener is removed when the object is disabled
            if (_button != null && _isListening)
            {
                _button.onClick.RemoveListener(OnButtonClick);
                _isListening = false;
            }
        }

        private void OnDestroy()
        {
            // Ensure listener is removed when the object is disabled
            if (_button != null && _isListening)
            {
                _button.onClick.RemoveListener(OnButtonClick);
                _isListening = false;
            }
        }

        [InspectorButton]
        public void OnButtonClick()
        {
            if (OnButtonClickGE == null)
            {
                Debug.LogWarning("No GameEvent assigned to " + gameObject.name);
                return;
            }

            OnButtonClickGE.Raise();
        }
    }
}