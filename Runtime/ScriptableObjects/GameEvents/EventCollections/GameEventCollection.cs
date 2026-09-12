using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.EventCollections
{
    /// <summary>
    /// This is a simple collection of GameEvents. 
    /// It can be used to trigger all events in the collection at once.
    /// </summary>
    [CreateAssetMenu(menuName = "UUP/EventSystem/EventCollections/GameEventCollection", fileName = "GameEventCollection")]
    public class GameEventCollection : CollectionBase
    {
        public GameEvent[] GameEvents;

        public override void RaiseAll()
        {
            foreach (var e in GameEvents)
            {
                e.Raise();
            }
        }
    }
}