
using UUP.CustomDataTypes;
using UUP.CustomDataTypes.Serializables;
using UUP.ScriptableObjects.GameEvents.Serialized;
using UnityEngine;

namespace UUP.Components.GameEvents
{
    public sealed class Vector3GameEventController : TGameEventController<Vector3GameEvent, Vector3>
    {
        public void Raise(Vector2 value)
        {
            gameEvent.Raise(new Vector3(value.x, value.y, 0));
        }
        public void Raise(Vector4 value)
        {
            gameEvent.Raise(new Vector3(value.x, value.y, value.z));
        }
        public void Raise(Quaternion value)
        {
            gameEvent.Raise(value.eulerAngles);
        }
        public void Raise(Component value)
        {
            gameEvent.Raise(value.transform.position);
        }
        public void RaisePos(SpatialOrientation value)
        {
            gameEvent.Raise(value.Position);
        }
        public void RaiseRot(SpatialOrientation value)
        {
            gameEvent.Raise(value.Rotation.eulerAngles);
        }
        public void RaisePos(SpatialOrientationSRZ value)
        {
            gameEvent.Raise(value.Get().Position);
        }
        public void RaiseRot(SpatialOrientationSRZ value)
        {
            gameEvent.Raise(value.Get().Rotation.eulerAngles);
        }

    }
}

