using UUP.ScriptableObjects.Data.Variables;
using UnityEngine;

namespace UUP.Misc.PlayerMovement
{
    [RequireComponent(typeof(Rigidbody))]
    public class SimpleMovement : MonoBehaviour
    {
        [SerializeField] private float walkSpeed = 4f; // Adjust the speed as needed
        [SerializeField] private float speedMultiplier = 3f; // speed-scaling for Sprinting
        private float currentSpeed;

        public BoolVariableSO isGrounded;
        [SerializeField] private float jumpForce = 10f;
        private bool _isGrounded;

        private Rigidbody rb;
        private Transform playerCamera;

        private void Start()
        {
            playerCamera = Camera.main.transform;
            rb = GetComponent<Rigidbody>();
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            currentSpeed = walkSpeed;
            _isGrounded = true;
        }

        private void Update()
        {
            _isGrounded = isGrounded.Value;

            if (UnityEngine.Input.GetKey(KeyCode.LeftShift) && _isGrounded)
            {
                currentSpeed = speedMultiplier * walkSpeed;
            }

            else
            {
                currentSpeed = walkSpeed;
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                Jump();
            }
        }

        void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            // Get input from keyboard
            float horizontalInput = UnityEngine.Input.GetAxis("Horizontal");
            float verticalInput = UnityEngine.Input.GetAxis("Vertical");

            // Calculate movement direction in camera space
            Vector3 cameraForward = playerCamera.forward;
            Vector3 cameraRight = playerCamera.right;

            // Calculate movement direction
            Vector3 movement = (cameraForward * verticalInput + cameraRight * horizontalInput).normalized;

            // Calculate the target velocity
            Vector3 targetVelocity = movement * currentSpeed;

            // Apply a smoothing factor to the velocity change for smoother movement
            Vector3 velocityChange = targetVelocity - rb.linearVelocity;
            velocityChange.y = 0f;

            rb.AddForce(velocityChange, ForceMode.VelocityChange);
        }

        private void Jump()
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }
}