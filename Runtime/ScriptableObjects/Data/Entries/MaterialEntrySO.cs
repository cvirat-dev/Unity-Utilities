
using UnityEngine;

namespace UUP.ScriptableObjects.Data.Entries
{
    /// <summary>
    /// Use case: Storing references to important game objects like the player, main camera, or key items.
    /// </summary>
    [CreateAssetMenu(
        menuName = "UUP/Data/Entries/MaterialEntry", 
        fileName = "MaterialEntry", order = 0)]
    public class MaterialEntrySO : EntrySO<Material>
    {
        public override void DebugValueContent()
        {
            // Debug informations: Name, Shader, Color
            Debug.Log($"Value: {Value.name} | Shader: {Value.shader.name} | Color: {Value.color}");
        }
    }
}
