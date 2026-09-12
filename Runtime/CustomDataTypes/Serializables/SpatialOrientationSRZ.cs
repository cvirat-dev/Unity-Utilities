using Newtonsoft.Json;
using System;
using UnityEngine;

namespace UUP.CustomDataTypes.Serializables
{
    /// <summary>
    /// Serializable Spatial Orientation
    /// </summary>
    [Serializable]
    public class SpatialOrientationSRZ : IConvertible<SpatialOrientation>
    {
        private Vector3 _position = Vector3.zero;
        private Vector3 _rotation = Vector3.zero;

        [SerializeField]
        public Vector3 Position 
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }
        
        [SerializeField]
        public Vector3 Rotation
        {
            get
            {
                return _rotation;
            }
            set
            {
                _rotation = value;
            }
        }

        public SpatialOrientation SpatialOrientation
        {
            get
            {
                return new SpatialOrientation(Position, Quaternion.Euler(Rotation));
            }
            set
            {
                Position = value.Position;
                Rotation = value.Rotation.eulerAngles;
            }
        }

        #region Constructors

        public SpatialOrientationSRZ()
        {
            Position = Vector3.zero;
            Rotation = Vector3.zero;
        }

        [JsonConstructor]
        public SpatialOrientationSRZ(Vector3 pos, Vector3 rot)
        {
            Position = pos;
            Rotation = rot;
        }

        public SpatialOrientationSRZ(Vector3 position, Quaternion quaternion)
        {
            Position = position;
            Rotation = quaternion.eulerAngles;
        }

        public SpatialOrientationSRZ(SpatialOrientation data)
        {
            Set(data);
        }
        #endregion

        #region Public Methods
        public void Set(SpatialOrientation data)
        {
            Position = data.Position;
            Rotation = data.Rotation.eulerAngles;
        }

        public void SetPosition(Vector3 pos)
        {
            Position = pos;
        }

        public void SetRotation(Vector3 rot)
        {
            Rotation = rot;
        }

        public void SetWithLocal(Transform transform)
        {
            Position = transform.localPosition;
            Rotation = transform.localRotation.eulerAngles;
        }

        public void SetWithWorld(Transform transform)
        {
            Position = transform.position;
            Rotation = transform.rotation.eulerAngles;
        }

        /// <summary>
        /// This method is used to convert the serializable object to the data type that the game event controller is using.
        /// </summary>
        /// <returns></returns>
        public SpatialOrientation ToSpatialOrientation()
        {
            return new SpatialOrientation(Position, Quaternion.Euler(Rotation));
        }

        public SpatialOrientation Get()
        {
            return ToSpatialOrientation();
        }
        #endregion
    }
}
