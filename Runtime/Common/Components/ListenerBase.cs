using UnityEngine;

namespace UUP.Common.Components
{
    /// <summary>
    /// Base class for listeners.
    /// </summary>
    public abstract class ListenerBase : MonoBehaviour, IListenerBase
    {
        protected virtual void OnEnable()
        {
            Subscribe();
        }

        protected virtual void OnDisable()
        {
            Unsubscribe();
        }

        protected virtual void OnDestroy()
        {
            Unsubscribe();
        }

        public abstract void Subscribe();
        public abstract void Unsubscribe();
    }
}
