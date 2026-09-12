using UUP.Common.Data.Variables;
using UUP.CustomAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace UUP.Components.Data.Variables.LerpedVariables
{
    public class LerpedVariableController<TLerpVar, TData> : MonoBehaviourTWithComment, 
        ILerpedVariableController where TLerpVar : ILerpedVariable<TData>
    {
        [SerializeField]
        protected TLerpVar lerpedVariable;

        [SerializeField, Range(0f, 1f)]
        float lerpSlider;

        public UnityEvent<float> LerpValueEvent;

        [InspectorButton]
        public void Lerp(float t)
        {
            lerpedVariable.Lerp(t);
        }

        private void OnValidate()
        {
            if (lerpedVariable == null)
            {
                return;
            }

            lerpedVariable.Lerp(lerpSlider);
            LerpValueEvent?.Invoke(lerpSlider);
        }
    }
}
