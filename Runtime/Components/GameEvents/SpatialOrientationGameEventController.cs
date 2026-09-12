using UUP.CustomAttributes;
using UUP.CustomDataTypes;
using UUP.CustomDataTypes.Serializables;
using UUP.ScriptableObjects.GameEvents.Serialized.CustomSerializables;
using UnityEngine;

namespace UUP.Components.GameEvents
{
    public class SpatialOrientationGameEventController : 
        TGameEventController<SpatialOrientationGameEvent, SpatialOrientation>
    {
        public void Raise(SpatialOrientationSRZ spatialOrientationS)
        {
            gameEvent.Raise(spatialOrientationS.ToSpatialOrientation());
        }

        [InspectorButton]
        public void RaisePosition(Vector3 position)
        {
            var spatialOrientation = new SpatialOrientation();
            spatialOrientation.Position = position;

            gameEvent.Raise(spatialOrientation);
        }

        [InspectorButton]
        public void RaiseRotation(Vector3 rotation)
        {
            var spatialOrientation = new SpatialOrientation();
            spatialOrientation.Rotation = Quaternion.Euler(rotation);
            gameEvent.Raise(spatialOrientation);
        }

        [InspectorButton]
        public void RaiseRotation(Quaternion rotation)
        {
            var spatialOrientation = new SpatialOrientation();
            spatialOrientation.Rotation = rotation;
            gameEvent.Raise(spatialOrientation);
        }

        [InspectorButton]
        public void RaisePositionAndRotation(Vector3 position, Vector3 rotation)
        {
            var spatialOrientation = new SpatialOrientation();
            spatialOrientation.Position = position;
            spatialOrientation.Rotation = Quaternion.Euler(rotation);
            gameEvent.Raise(spatialOrientation);
        }

        [InspectorButton]
        public void RaisePositionAndRotation(Vector3 position, Quaternion rotation)
        {
            var spatialOrientation = new SpatialOrientation();
            spatialOrientation.Position = position;
            spatialOrientation.Rotation = rotation;
            gameEvent.Raise(spatialOrientation);
        }

        [InspectorButton]
        public void RaiseWithLocal(Transform transform)
        {
            var spatialOrientation = new SpatialOrientation();
            spatialOrientation.Position = transform.localPosition;
            spatialOrientation.Rotation = transform.localRotation;
            gameEvent.Raise(spatialOrientation);
        }

        [InspectorButton]
        public void RaiseWithWorld(Transform transform)
        {
            var spatialOrientation = new SpatialOrientation();
            spatialOrientation.Position = transform.position;
            spatialOrientation.Rotation = transform.rotation;
            gameEvent.Raise(spatialOrientation);
        }

    }
}
