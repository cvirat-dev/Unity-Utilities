using UnityEngine;

namespace UUP.Common.Events
{
    public interface IGameEventBase1<TData>
    {
        void Raise(TData data);
        void RegisterListener(Component listener);
        void UnregisterListener(Component listener);
    }
}