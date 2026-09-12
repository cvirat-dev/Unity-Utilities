using UUP.Debugging;
using UnityEngine;
using UUP.CustomDataTypes.Serializables;
using System;

namespace UUP.CustomDataTypes
{
    /// <summary>
    /// This class represents the spatial orientation of an object in the scene.
    /// Therefore it contains two properties: Position and Rotation.
    /// </summary>
    /// <remarks>
    /// This class does not represent a <see cref="Transform"/> object, therefore the concept of global or local space is not considered.
    /// </remarks>
    [System.Serializable]
    public class SpatialOrientation : IDebuggable
    {
        private Vector3 _position = Vector3.zero;
        private Quaternion _rotation = Quaternion.identity;

        public Vector3 Position
        {
            get => _position;
            set => _position = value;
        }

        // Max 2 decimal places
        public string PositionMessage 
            => $"({Mathf.Round(_position.x * 100f) / 100f}, {Mathf.Round(_position.y * 100f) / 100f}, {Mathf.Round(_position.z * 100f) / 100f})";

        public Quaternion Rotation
        {
            get => _rotation;
            set => _rotation = value;
        }

        public string RotationMessage
        {
            get
            {
                Vector3 euler = _rotation.eulerAngles;
                return $"({Mathf.Round(euler.x * 100f) / 100f}, {Mathf.Round(euler.y * 100f) / 100f}, {Mathf.Round(euler.z * 100f) / 100f})";
            }
        }

        public SpatialOrientation()
        {
            _position = Vector3.zero;
            _rotation = Quaternion.identity;
        }

        public SpatialOrientation(float[] positions, float[] rotations)
        {
            if (positions.Length != 3)
                throw new ArgumentException("Positions array must have exactly 3 elements.");
            if (rotations.Length != 4)
                throw new ArgumentException("Rotations array must have exactly 4 elements.");
            _position = new Vector3(positions[0], positions[1], positions[2]);
            _rotation = new Quaternion(rotations[0], rotations[1], rotations[2], rotations[3]);
        }

        public SpatialOrientation(SpatialOrientation spatialOrientation)
        {
            _position = spatialOrientation.Position;
            _rotation = spatialOrientation.Rotation;
        }

        public SpatialOrientation(SpatialOrientationSRZ spatialOrientationSRZ)
        {
            _position = spatialOrientationSRZ.SpatialOrientation.Position;
            _rotation = spatialOrientationSRZ.SpatialOrientation.Rotation;
        }

        public SpatialOrientation(Vector3 position, Quaternion rotation)
        {
            _position = position;
            _rotation = rotation;
        }

        public SpatialOrientation(Transform transform, bool useLocal = false)
        {
            if (useLocal)
            {
                _position = transform.localPosition;
                _rotation = transform.localRotation;
            }
            else
            {
                _position = transform.position;
                _rotation = transform.rotation;
            }
        }

        public void UpdateValues(Vector3 position, Quaternion rotation)
        {
            _position = position;
            _rotation = rotation;
        }

        public void DebugState()
        {
            Debug.Log($"Position: {_position}, Rotation: {_rotation}");
        }

        public override string ToString()
        {
            return $"Position: {PositionMessage}, Rotation: {RotationMessage}";
        }
    }
}