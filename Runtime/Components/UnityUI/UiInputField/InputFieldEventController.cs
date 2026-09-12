using UUP.ScriptableObjects.Data.Variables;
using UnityEngine;
using UnityEngine.UI;

namespace UUP.Components.UnityUI.UiInputField
{
    public class InputFieldEventController : MonoBehaviour
    {
        [SerializeField] StringVariableSO InputFieldTextSO;
        private InputField _inputField;

        private void Start()
        {
            _inputField = GetComponent<InputField>();
            if (InputFieldTextSO == null)
            {
                Debug.LogError("InputFieldTextSO is not set in " + this.name);
            }
        }

        private void OnEnable()
        {
            if (_inputField != null)
            {
                _inputField.onValueChanged.AddListener(OnInputFieldChange);
            }
        }

        private void OnDisable()
        {
            if (_inputField != null)
            {
                _inputField.onValueChanged.RemoveListener(OnInputFieldChange);
            }
        }

        public void OnInputFieldChange(string inputFieldText)
        {
            InputFieldTextSO.Value = inputFieldText;
        }
    }
}