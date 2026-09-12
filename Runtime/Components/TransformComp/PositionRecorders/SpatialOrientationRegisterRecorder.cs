using UUP.CustomDataTypes;
using UUP.Enums;
using UUP.ScriptableObjects.Data.Entries.NotifiedRegisters;
using UnityEngine;

namespace UUP.Components.TransformComp.PositionRecorders
{
    public class SpatialOrientationRegisterRecorder : MonoBehaviour
    {
        [SerializeField] private SpatialOrientationNotifRegister positionsRegisterSO;
        [SerializeField] private WorldType worldType;

        private void Awake()
        {
            if (positionsRegisterSO == null)
            {
                Debug.LogWarning($"The {nameof(SpatialOrientationNotifRegister)} is not set. Please set it in the inspector.");
                return;
            }
        }

        public void RecordNextPosition()
        {
            var nextIndex = positionsRegisterSO.GetIndexOfFirstEmptyEntry();
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
            try
            {
                positionsRegisterSO.AddAt(newPosition, nextIndex);
            }
            catch (System.Exception)
            {
                Debug.LogWarning($"The {nameof(SpatialOrientationNotifRegister)} is full. Please remove some entries before adding new ones.");
            }
        }

        public void RecordPositionAt(int index)
        {
            if (index < 0 || index >= positionsRegisterSO.Entries.Length)
            {
                Debug.LogWarning($"The index {index} is out of bounds. The index should be between 0 and {positionsRegisterSO.Entries.Length - 1}.");
                return;
            }
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
            positionsRegisterSO.AddAt(newPosition, index);
        }
    }
}
