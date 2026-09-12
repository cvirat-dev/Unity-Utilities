using UnityEngine;

namespace UUP.Common.Data.Variables
{
    public class VariableSOController<TVariable, TData> : MonoBehaviour where TVariable : INotifiedVariable<TData>
    {
        [SerializeField]
        protected TVariable variable;

        public void SetValue(TData value)
        {
            variable.Value = value;
        }
    }
}
