using UUP.CustomDataTypes;
using UnityEngine;

namespace UUP.ScriptableObjects.Data.Entries
{
    /// <summary>
    /// Use case: 
    ///     - Similar to a Transform, but without scale.
    ///     - Useful for storing the position and rotation of objects like for e.g. Camera-Positions for cut scenes.
    /// </summary>
    [CreateAssetMenu(
        menuName = "UUP/Data/Entries/SpatialOrientationEntry", 
        fileName = "SpatialOrientationEntry", order = 0)]
    public class SpatialOrientationEntrySO : EntrySO<SpatialOrientation>
    {
        public override void DebugValueContent()
        {
            if(Value == null)
            {
                return;
            }

            Value.DebugState();
        }
    }
}