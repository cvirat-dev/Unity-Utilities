using UUP.ScriptableObjects.Data.Variables;
using UnityEngine;

namespace UUP.Common.Components
{
    /// <summary>
    /// Inspired by the Data-Binding-Pattern
    /// Allows to automatically bind a VariableSO to a component
    /// </summary>
    /// <typeparam name="TComp"></typeparam>
    /// <typeparam name="TVar"></typeparam>
    /// <typeparam name="TData"></typeparam>
    public abstract class DataBindingController<TComp, TVar, TData> : ListenerBase
        where TComp : UnityEngine.Component
        where TVar : VariableSO<TData>
    {
        protected TComp _component;
        
        [SerializeField, Tooltip("VariableSO to bind to. In order to work, this SO must implement the IVariableSO interface.")]
        TVar variable;

        private void Awake()
        {
            if (variable == null)
            {
                Debug.LogError($"VariableSO is null on {gameObject.name}");
                Debug.Break();
                return;
            }

            _component = GetComponent<TComp>();
             
            if(_component == null)
            {
                Debug.LogWarning($"{this.name} : Component is missing on {gameObject.name}. Will add it manually.");
                // Add component
                this.gameObject.AddComponent<TComp>();
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            Bind(variable.Value);
        }

        /// <summary>
        /// Bind the Event-Data to the component
        /// </summary>
        /// <param name="data"></param>
        protected abstract void Bind(TData data);

        public override void Subscribe()
        {
            variable.OnValueSet += Bind;
        }

        public override void Unsubscribe()
        {
            variable.OnValueSet -= Bind;
        }

    }
}
