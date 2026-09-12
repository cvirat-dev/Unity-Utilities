using UUP.CustomDataTypes;
using UUP.Enums;
using UUP.ScriptableObjects.Data.Entries;
using UnityEngine;

namespace UUP.Misc.GameObjectPositioning
{
    /// <summary>
    /// A simple controller that updates the transform of the game object based on the values of 
    /// a SpatialOrientationEntrySO using the Observer pattern.
    /// </summary>
    public class SpatialOrientationSOController : MonoBehaviour
    {
        [SerializeField] private SpatialOrientationEntrySO spatialOrientationEntry;
        [SerializeField] private WorldType worldType;

        private void OnEnable()
        {
            spatialOrientationEntry.OnValueSet += UpdateTransform;
            UpdateTransform(spatialOrientationEntry.Value);
        }

        private void OnDisable()
        {
            spatialOrientationEntry.OnValueSet -= UpdateTransform;
        }

        private void UpdateTransform(SpatialOrientation posRotObject)
        {
            if (worldType == WorldType.Local)
            {
                transform.localPosition = spatialOrientationEntry.Value.Position;
                transform.localRotation = spatialOrientationEntry.Value.Rotation;
            }
            else
            {
                transform.position = spatialOrientationEntry.Value.Position;
                transform.rotation = spatialOrientationEntry.Value.Rotation;
            }
        }
    }
}