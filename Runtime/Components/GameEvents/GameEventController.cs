using UUP.ScriptableObjects.GameEvents;
using UnityEngine;

namespace UUP.Components.GameEvents
{
    /// <summary>
    /// Allows to couple a <see cref="GameEvent"/> with a Unity event.
    /// </summary>
    public class GameEventController : MonoBehaviourTWithComment
    {
        [SerializeField]
        protected GameEvent GameEvent;

        public void Raise()
        {
            GameEvent.Raise();
        }
    }
}
