
using UnityEngine;

namespace UUP.ScriptableObjects.Data.Entries
{
    /// <summary>
    /// Use case: Storing references to important game objects like the player, main camera, or key items.
    /// </summary>
    [CreateAssetMenu(
        menuName = "UUP/Data/Entries/GameobjectEntry", 
        fileName = "GameobjectEntry", order = 0)]
    public class GameobjectEntrySO : EntrySO<GameObject>
    {
        public override void DebugValueContent()
        {
            // Debug informations: Name, IsActive, Tag, Layer
            Debug.Log($"Value: {Value.name} | IsActive: {Value.activeSelf} | Tag: {Value.tag} | Layer: {Value.layer}");
        }
    }
}
