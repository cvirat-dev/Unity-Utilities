using UnityEngine;

namespace UUP.Components.CameraSystem
{
    /// <summary>
    /// Attach this class to a camera in order to move it like in the scene-view while play-mode
    /// </summary>
    /// <remarks>
    /// The FocusObject-Method allows to move towards a Gameobject with a mouse-click 
    /// if the camera looks it it's direction 
    /// </remarks>
    [RequireComponent(typeof(Camera))]
    public class SceneLikeCameraWithFocus : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] float moveSpeed = 0.5f;
        [SerializeField] float rotateSpeed = 10.0f;
        [SerializeField] float scrollSpeed = 5.0f;

        [Header("Focus Object")]
        [SerializeField] float focusLimit = 100f;
        [SerializeField] float minFocusDistance = 5.0f;
        private float doubleClickTime = .25f;
        private float coolDown = 0;

        [SerializeField] KeyCode forwardKey = KeyCode.W;
        [SerializeField] KeyCode backKey = KeyCode.S;
        [SerializeField] KeyCode leftKey = KeyCode.A;
        [SerializeField] KeyCode rightKey = KeyCode.D;

        [SerializeField] KeyCode anchoredMoveKey = KeyCode.Mouse2;
        [SerializeField] KeyCode anchoredRotateKey = KeyCode.Mouse1;

        private void Update()
        {
            // Double click for focus
            if (coolDown > 0 && UnityEngine.Input.GetKeyDown(KeyCode.Mouse0))
            {
                FocusObject();
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.Mouse0))
            {
                coolDown = doubleClickTime;
            }

            coolDown -= Time.deltaTime;
        }

        private void FocusObject()
        {
            // If we are looking at an gameobject in the scene, go to its position
            Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, focusLimit))
            {
                var target = hit.collider.gameObject;
                var targetPos = target.transform.position;
                var targetSize = hit.collider.bounds.size;

                transform.position = targetPos + GetOffset(targetPos, targetSize);
                transform.LookAt(target.transform);
            }
        }

        private Vector3 GetOffset(Vector3 targetPos, Vector3 targetSize)
        {
            Vector3 dirToTarget = targetPos - transform.position;
            float focusDistance = Mathf.Max(targetSize.x, targetSize.z);
            focusDistance = Mathf.Clamp(focusDistance, minFocusDistance, focusDistance);
            return -dirToTarget.normalized * focusDistance;
        }

        private void FixedUpdate()
        {
            var move = Vector3.zero;

            // Move and rotate the camera

            // Move the camera with forward, back, left and right keys
            if (UnityEngine.Input.GetKey(forwardKey))
            {
                move += Vector3.forward * moveSpeed;
            }
            if (UnityEngine.Input.GetKey(backKey))
            {
                move += Vector3.back * moveSpeed;
            }
            if (UnityEngine.Input.GetKey(leftKey))
            {
                move += Vector3.left * moveSpeed;
            }
            if (UnityEngine.Input.GetKey(rightKey))
            {
                move += Vector3.right * moveSpeed;
            }

            var mouseMovementY = UnityEngine.Input.GetAxis("Mouse Y");
            var mouseMovementX = UnityEngine.Input.GetAxis("Mouse X");


            // Move the camera when anchored
            if (UnityEngine.Input.GetKey(anchoredMoveKey))
            {
                move -= Vector3.up * mouseMovementY * moveSpeed;
                move -= Vector3.right * mouseMovementX * moveSpeed;
            }

            //Rotate the camera 
            if (UnityEngine.Input.GetKey(anchoredRotateKey))
            {
                transform.RotateAround(transform.position, transform.right, mouseMovementY * -rotateSpeed);
                transform.RotateAround(transform.position, Vector3.up, mouseMovementX * rotateSpeed);
            }

            transform.Translate(move);
        }

        private void LateUpdate()
        {
            // Scroll to zoom
            var mouseScroll = UnityEngine.Input.GetAxis("Mouse ScrollWheel");
            transform.Translate(Vector3.forward * mouseScroll * scrollSpeed);
        }
    }
}