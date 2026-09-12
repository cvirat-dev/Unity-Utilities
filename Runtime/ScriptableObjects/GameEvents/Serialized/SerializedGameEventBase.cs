using UUP.Common.GameEvents;
using UUP.CustomAttributes;

namespace UUP.ScriptableObjects.GameEvents.Serialized
{
    public abstract class SerializedGameEventBase<TListener, TData> : GameEventBase2<TListener,
        TData>, ISerializedGameEventBase where TListener : GameEventListenerBase1<TData>
    {
        [InspectorButton]
        public abstract void RaiseWithData();
    }
}
