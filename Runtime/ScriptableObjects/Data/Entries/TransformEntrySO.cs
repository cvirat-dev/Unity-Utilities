
using UnityEngine;

namespace UUP.ScriptableObjects.Data.Entries
{
    /// <summary>
    /// Use case: Storing references to important game objects like the player, main camera, or key items.
    /// </summary>
    [CreateAssetMenu(
        menuName = "UUP/Data/Entries/TransformEntry", 
        fileName = "TransformEntry", order = 0)]
    public class TransformEntrySO : EntrySO<Transform>
    {
        public override void DebugValueContent()
        {
            // Debug informations: Position, LocalPosition, Rotation, LocalRotation, Scale
            string positionLog = Value.position.ToString();
            Debug.Log($"Position : {positionLog}");
            string localPositionLog = Value.localPosition.ToString();
            Debug.Log($"Local Position : {localPositionLog}");
            string rotationLog = Value.rotation.eulerAngles.ToString();
            Debug.Log($"Rotation : {rotationLog}");
            string localRotationLog = Value.localRotation.eulerAngles.ToString();
            Debug.Log($"Local Rotation : {localRotationLog}");
            string scaleLog = Value.localScale.ToString();
            Debug.Log($"Scale : {scaleLog}");
        }
    }
}
