using UUP.Common.Components;
using UnityEngine.Events;

namespace UUP.Common.Data.Variables
{
    public class VariableSOListener<TVariable, TData> : ListenerBase
        where TVariable : INotifiedVariable<TData>
    {
        public TVariable Variable;
        public UnityEvent<TData> OnValueSetEvent;

        protected override void OnEnable()
        {
            base.OnEnable();
            OnValueSetEvent.Invoke(Variable.Value);
        }

        public override void Subscribe()
        {
            Variable.OnValueSet += (value) => OnValueSetEvent.Invoke(value);
        }

        public override void Unsubscribe()
        {
            Variable.OnValueSet -= (value) => OnValueSetEvent.Invoke(value);
        }
    }
}
