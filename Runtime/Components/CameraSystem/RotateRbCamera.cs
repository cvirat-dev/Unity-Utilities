using UnityEngine;

namespace UUP.Components.CameraSystem
{
    /// <summary>
    /// This class rotates the camera using Rigidbody physics. 
    /// The camera rotates around its local axes in response to the arrow keys.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Camera))]
    public class RotateRbCamera : MonoBehaviour
    {
        [SerializeField] float torqueSpeed = 12f; 
        [SerializeField] float damping = 8f;
        [SerializeField] float startYRotationValue;
        private Rigidbody cameraRigidbody; 
        private Transform cameraTransform; 
        private float rotateVerticalInput; 
        private float rotateHorizontalInput;
        private float localPositionX;
        private float localPositionY;
        private float localPositionZ;

        void OnEnable()
        {
            // Get the Rigidbody and Transform components attached to the camera
            cameraRigidbody = GetComponent<Rigidbody>();
            cameraTransform = GetComponent<Transform>();

            localPositionX = cameraTransform.localPosition.x;
            localPositionY = cameraTransform.localPosition.y;
            localPositionZ = cameraTransform.localPosition.z;

            cameraTransform.localRotation = Quaternion.Euler(0f, startYRotationValue, 0f);
        }

        void OnDisable()
        {
            cameraTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }

        void FixedUpdate()
        {
            // Read the input values of the arrow keys
            rotateHorizontalInput = UnityEngine.Input.GetAxis("Horizontal");
            rotateVerticalInput = -UnityEngine.Input.GetAxis("Vertical");

            if (rotateHorizontalInput != 0f || rotateVerticalInput != 0f)
            {
                // Calculate the torque to apply to the camera in local space
                Vector3 torque = cameraTransform.TransformDirection(new Vector3(rotateVerticalInput, rotateHorizontalInput, 0f)) * torqueSpeed;

                // Apply the torque to the camera Rigidbody
                cameraRigidbody.AddTorque(torque);
            }

            // Apply damping to the camera Rigidbody
            cameraRigidbody.angularVelocity *= (1f - damping * Time.deltaTime);

            cameraTransform.localPosition = new Vector3(localPositionX, localPositionY, localPositionZ);

            Quaternion currentRotation = cameraTransform.localRotation;
            Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y, 0f);
            cameraTransform.localRotation = newRotation;
        }
    }
}