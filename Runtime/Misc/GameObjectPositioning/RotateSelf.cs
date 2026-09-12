using UUP.CustomAttributes;
using UUP.CustomAttributes.CustomTargets;
using UUP.Enums;
using UUP.Extensions;
using UnityEngine;

namespace UUP.Misc.GameObjectPositioning
{
    /// <summary>
    /// This class was used tp rotate 3D-Numbers over the virtual SteamVR-Trackers
    /// allowing to associate the number with the tracker.
    /// </summary>
    public class RotateSelf : MonoBehaviourT
    {
        [SerializeField] private AxisSelect rotationAxis;
        [SerializeField] float rotationSpeed = 65f; 
        [SerializeField] bool rotate = true;
        private Vector3 _rotationAxisVector;
        private Transform _initialT;

        private void Awake()
        {
            _initialT = transform;
            _rotationAxisVector = _rotationAxisVector.GetAxisVector(rotationAxis);
        }

        private void OnEnable()
        {
            _rotationAxisVector = _rotationAxisVector.GetAxisVector(rotationAxis);
        }

        private void OnValidate()
        {
            _rotationAxisVector = _rotationAxisVector.GetAxisVector(rotationAxis);
        }

        // Update is called once per frame
        void Update()
        {
            if (!rotate)
                return;

            transform.Rotate(_rotationAxisVector, rotationSpeed * Time.deltaTime);
        }

        [InspectorButton]
        public void StopRotation() => rotate = false;

        [InspectorButton]
        public void StartRotation() => rotate = true;

        public void ResetAndStop()
        {
            rotate = false;
            transform.rotation = _initialT.rotation;
        }
    }
}