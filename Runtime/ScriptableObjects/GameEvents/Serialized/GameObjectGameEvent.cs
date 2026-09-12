
using UUP.Components.GameEvents;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.Serialized
{
    [CreateAssetMenu(menuName = "UUP/EventSystem/GameObjectGameEvent", fileName = "GameObjectGameEvent")]
    public sealed class GameObjectGameEvent : SerializedGameEvent<GameObject, GameObjectEventListener>
    {
        // Use this Prefabs
        // Scene-GameObjects wont work : Because ScriptableObject cannot reference Scene-GameObjects
    }
}
