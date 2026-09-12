
using System;

namespace UUP.ScriptableObjects.Operations.IndexedArraysHandlers
{
    /// <summary>
    /// Base class for indexed array event handlers.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class IndexedArrayEventHandlerBase<T> : ScriptableObjectTWithComment, IIndexedArrayEventHandler
    {
        public event Action<T> OnResult;

        protected void InvokeEvent(T result)
        {
            OnResult?.Invoke(result);
        }

        public virtual void HandleEventManagement()
        {
        }
    }
}