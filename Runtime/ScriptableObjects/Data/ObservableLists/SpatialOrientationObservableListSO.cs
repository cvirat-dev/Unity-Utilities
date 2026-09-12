using UUP.CustomDataTypes;
using UnityEngine;
using UUP.CustomDataTypes.Serializables;
using System.Collections.Generic;

namespace UUP.ScriptableObjects.Data.ObervableLists
{
    [CreateAssetMenu(menuName = "UUP/Data/Observable_Lists/SpatialOrientation", fileName = "SpatialOrientation")]
    public class SpatialOrientationObservableListSO : OberservableListSO<SpatialOrientation>
    {
        public List<SpatialOrientationSRZ> ToSpatialOrientationSRZ()
        {
            List<SpatialOrientationSRZ> spatialOrientationSRZs = new List<SpatialOrientationSRZ>();
            foreach (var spatialOrientation in Value)
            {
                spatialOrientationSRZs.Add(new SpatialOrientationSRZ(spatialOrientation));
            }
            return spatialOrientationSRZs;
        }

        public void Set(List<SpatialOrientationSRZ> spatialOrientationSRZs)
        {
            Clear();
            foreach (var spatialOrientationSRZ in spatialOrientationSRZs)
            {
                Add(new SpatialOrientation(spatialOrientationSRZ));
            }
        }
    }
}