using UUP.Common.Events;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents
{
    public abstract class GameEventBase1<TData> : GameEventBase0, IGameEventBase1<TData>
    {
        public abstract void Raise(TData data);

        public abstract void RegisterListener(Component listener);

        public abstract void UnregisterListener(Component listener);
    }
}
