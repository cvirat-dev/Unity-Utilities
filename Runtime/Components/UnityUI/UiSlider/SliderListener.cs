using UUP.ScriptableObjects.Data.Variables;
using UnityEngine;
using UnityEngine.UI;

namespace UUP.Components.UnityUI.UiSlider
{
    public class SliderListener : MonoBehaviour
    {
        [SerializeField] FloatVariableSO SliderValueSO;
        [HideInInspector] public bool ShowGameEvent = true;
        [HideInInspector] public bool ShowSliderVariable;

        private Slider _slider;

        private void OnEnable()
        {
            if (SliderValueSO == null)
            {
                Debug.LogError("Reference missing");
                return;
            }

            _slider = GetComponent<Slider>();

            if (_slider == null)
            {
                Debug.LogWarning("Slider-component not found!");
                return;
            }
            
            _slider.onValueChanged.AddListener(OnSliderChange);
            
            // initial value pass
            var value = _slider.value;
            OnSliderChange(value);
        }

        private void OnDisable()
        {
            if (_slider != null)
            {
                _slider.onValueChanged.RemoveListener(OnSliderChange);
            }
        }

        public void OnSliderChange(float sliderValue)
        {
            if (SliderValueSO == null)
            {
                Debug.LogError("Reference missing");
                return;
            }

            SliderValueSO.Value = sliderValue;
        }
    }
}
