using System;

namespace UUP.Common.Data.Variables
{
    public interface INotifiedVariable<T>
    {
        /// <summary>
        /// The value of this "entry"
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// May seem redundant, but allows more control over the inspector 
        /// by allowing to use the <see cref="CustomAttributes.InspectorButtonAttribute"/> for more control over the inspector
        /// </summary>
        /// <param name="val"></param>
        public void SetValue(T val);

        /// <summary>
        /// Invokes when the value of the variable changes.
        /// </summary>
        event Action<T> OnValueSet;
    }
}
