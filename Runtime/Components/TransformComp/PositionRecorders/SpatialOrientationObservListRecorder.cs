using UUP.CustomDataTypes;
using UUP.Enums;
using UUP.ScriptableObjects.Data.ObervableLists;
using UnityEngine;

namespace UUP.Components.TransformComp.PositionRecorders
{
    public class SpatialOrientationObservListRecorder : MonoBehaviour
    {
        [SerializeField] private SpatialOrientationObservableListSO positions;
        [SerializeField] private WorldType worldType;

        private void Awake()
        {
            if (positions == null)
            {
                Debug.LogWarning($"The {nameof(SpatialOrientationObservableListSO)} is not set. Please set it in the inspector.");
                return;
            }
        }

        public void RecordNextPosition()
        {
            var newPosition = new SpatialOrientation();
            switch (worldType)
            {
                case WorldType.Global:
                    newPosition.Position = transform.position;
                    newPosition.Rotation = transform.rotation;
                    break;
                case WorldType.Local:
                    newPosition.Position = transform.localPosition;
                    newPosition.Rotation = transform.localRotation;
                    break;
            }
            positions.Add(newPosition);
        }
    }
}
