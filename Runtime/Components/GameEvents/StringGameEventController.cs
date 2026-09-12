
using UUP.CustomDataTypes;
using UUP.CustomDataTypes.Serializables;
using UUP.ScriptableObjects.GameEvents.Serialized;
using UnityEngine;

namespace UUP.Components.GameEvents
{
    public sealed class StringGameEventController : TGameEventController<StringGameEvent, string>
    {
        // Add overloads for all data types
        public void Raise(int value)
        {
            gameEvent.Raise(value.ToString());
        }

        public void Raise(float value)
        {
            gameEvent.Raise(value.ToString());
        }

        public void Raise(bool value)
        {
            gameEvent.Raise(value.ToString());
        }

        public void Raise()
        {
            gameEvent.Raise(string.Empty);
        }

        public void Raise(Vector3 value)
        {
            gameEvent.Raise(value.ToString());
        }

        public void Raise(Vector2 value)
        {
            gameEvent.Raise(value.ToString());
        }

        public void Raise(Vector4 value)
        {
            gameEvent.Raise(value.ToString());
        }

        public void Raise(Quaternion value)
        {
            gameEvent.Raise(value.ToString());
        }

        public void Raise(Component value)
        {
            gameEvent.Raise(value.name);
        }

        public void Raise(SpatialOrientation value)
        {
            gameEvent.Raise(value.ToString());
        }

        public void Raise(SpatialOrientationSRZ value)
        {
            gameEvent.Raise(value.Get().ToString());
        }
    }
}
