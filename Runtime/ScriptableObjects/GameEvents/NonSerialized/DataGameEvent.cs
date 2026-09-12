using UUP.Components.GameEvents;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.NonSerialized
{
    /// <summary>
    /// Based on <see cref="System.Object"/> which is the base class for all types in C#.
    /// This GameEvent allows to pass any kind of data to the listeners.
    /// It is a quick solution but not type-safe and requires using type casting for using the listeners response.
    /// </summary>
    [CreateAssetMenu(menuName = "UUP/EventSystem/DataGameEvent", fileName = "DataGameEvent", order = -100)]
    public class DataGameEvent : GameEventBase2<DataGameEventListener, object>
    {
    }
}

