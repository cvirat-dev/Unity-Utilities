using UUP.Coroutines;
using UUP.CustomAttributes;
using UUP.CustomAttributes.CustomTargets;
using UUP.CustomDataTypes;
using UUP.CustomDataTypes.Serializables;
using UUP.ScriptableObjects.GameEvents;
using UUP.ScriptableObjects.GameEvents.Serialized;
using UUP.ScriptableObjects.GameEvents.Serialized.CustomSerializables;
using System;
using UnityEngine;
using UnityEngine.Events;
using UUP.ScriptableObjects.Data.Variables;

namespace UUP.Components.CameraSystem
{
    /// <summary>
    /// This class allows to control a GameObject with a RigidBody with the same mouse-inputs as in the Scene-View
    /// </summary>
    /// <remarks>
    /// This can be used as a camera-controller for a 3D-Scene
    /// The RigidBody-Component allows to smooth damp the camera movements
    /// We do not automatically add a camera-component on this GameObject, because if used with the Cinemachine, the camera may be on another GameObject
    /// </remarks>
    [RequireComponent(typeof(Rigidbody))]
    public class SceneLikeRbCameraController : MonoBehaviourT
    {
        public event Action OnCameraReset;
        public event Action OnCameraMovement;
        public UnityEvent OnMoveRoutineStart = new();
        public UnityEvent<float> OnMoveroutineProgress = new();
        public UnityEvent<SpatialOrientation> OnMoveRoutineEnd = new();
        public UnityEvent<SpatialOrientation> OnMoveroutineStopped = new();

        [Tooltip("Use GameEvents to notify about the start, progress and end of the move-routine")]
        public bool useGameEvents;
        [ShowIf(nameof(useGameEvents))]
        public GameEvent OnMoveRoutineStartEvent;
        [ShowIf(nameof(useGameEvents))]
        public FloatGameEvent OnMoveroutineProgressEvent;
        [ShowIf(nameof(useGameEvents))]
        public SpatialOrientationGameEvent OnMoveRoutineEndEvent;
        [ShowIf(nameof(useGameEvents))]
        public SpatialOrientationGameEvent OnMoveroutineStoppedEvent;

        [Tooltip("Use a ScriptableObject to track the camera position")]
        public bool useCameraPositionTrackerSO;
        [ShowIf(nameof(useCameraPositionTrackerSO))]
        public SpatialOrientationVariableSO CameraPositionTracker; 

        private const float MOUSE_MOVE_SPEED_MAX = 500f;
        private const float MOUSE_ROTATE_SPEED_MAX = 200f;
        private const float SCROLL_SPEED_MAX = 5000f;

        [SerializeField, Range(1f, 100f), Tooltip("%-Value")] private float mouseMoveSpeed = 50f;
        [SerializeField, Range(1f, 100f), Tooltip("%-Value")] private float mouseRotateSpeed = 50f;
        [SerializeField, Range(1f, 100f), Tooltip("%-Value")] private float scrollSpeed = 50f;
        [SerializeField] float moveDuration = 2f;

        private KeyCode _anchoredMoveKey = KeyCode.Mouse2;
        private KeyCode _anchoredRotateKey = KeyCode.Mouse1;
        private Vector3 _startLocalPos;
        private Quaternion _startLocalRot;
        private float _moveIntensity;
        private float _rotateIntensity;
        private float _scrollIntensity;
        private Rigidbody _rb;
        private SimpleRoutine _simpleRoutine;
        private SpatialOrientation _target;

        #region Properties
        public SpatialOrientation CurrentPosition => new(transform.position, transform.rotation);
        #endregion

        #region internal & private methods
        private void Awake()
        {
            _startLocalPos = transform.localPosition;
            _startLocalRot = transform.localRotation;
            _rb = GetComponent<Rigidbody>();

            if( _rb != null )
            {
                _rb.inertiaTensorRotation = Quaternion.identity;
            }

            else
            {
                Debug.LogError("RigidBody nicht gefunden!");
                return;
            }

            _simpleRoutine = InitRoutine();
        }

        private void Start()
        {
            _rb.useGravity = false;
            SetIntensityParams();
        }

        private void FixedUpdate()
        {
            var mouseMovementY = UnityEngine.Input.GetAxis("Mouse Y");
            var mouseMovementX = UnityEngine.Input.GetAxis("Mouse X");

            if (UnityEngine.Input.GetKey(_anchoredMoveKey))
            {
                OnCameraMovement?.Invoke();
                Vector3 moveDirection = -Vector3.up * mouseMovementY - Vector3.right * mouseMovementX;
                moveDirection = transform.TransformDirection(moveDirection);

                _rb.AddForce(moveDirection * _moveIntensity);
            }


            if (UnityEngine.Input.GetKey(_anchoredRotateKey))
            {
                OnCameraMovement?.Invoke();
                _rb.AddRelativeTorque(-_rotateIntensity * mouseMovementY * Vector3.right);
                _rb.AddRelativeTorque(_rotateIntensity * mouseMovementX * Vector3.up);
            }

            // Block the z-component of the rotation in order to avoid unwanted rotations 
            Quaternion currentRotation = _rb.rotation;
            currentRotation.eulerAngles = new Vector3(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y, 0f);
            _rb.MoveRotation(currentRotation);

        }

        private void Update()
        {
            if (useCameraPositionTrackerSO)
            {
                CameraPositionTracker.Value = new SpatialOrientationSRZ(transform.position, transform.rotation);
            }
        }

        private void LateUpdate()
        {
            var mouseScroll = UnityEngine.Input.GetAxis("Mouse ScrollWheel");

            var scrollForce = _scrollIntensity * mouseScroll * Vector3.forward;

            if (scrollForce != Vector3.zero)
            {
                OnCameraMovement?.Invoke();
                _rb.AddRelativeForce(scrollForce);
            }
        }

        private float GetMappedValue(float value, float max)
        {
            return (value / 100f) * max;
        }

        private void SetIntensityParams()
        {
            _moveIntensity = GetMappedValue(mouseMoveSpeed, MOUSE_MOVE_SPEED_MAX);
            _rotateIntensity = GetMappedValue(mouseRotateSpeed, MOUSE_ROTATE_SPEED_MAX);
            _scrollIntensity = GetMappedValue(scrollSpeed, SCROLL_SPEED_MAX);
        }

        private SimpleRoutine InitRoutine()
        {
            SimpleRoutine simpleRoutine = new();
            simpleRoutine.OnRoutineStart += () => 
            { 
                OnMoveRoutineStart?.Invoke();
                OnMoveRoutineStartEvent?.Raise();
            };
            simpleRoutine.OnRoutineProgress += (float t) => 
            { 
                OnMoveroutineProgress?.Invoke(t);
                OnMoveroutineProgressEvent?.Raise(t);
            };
            simpleRoutine.OnRoutineComplete += () => 
            { 
                OnMoveRoutineEnd?.Invoke(_target);
                OnMoveRoutineEndEvent?.Raise(_target);
            };
            simpleRoutine.OnRoutineStop += () => {
                var stopPos = new SpatialOrientation(transform.position, transform.rotation);
                OnMoveroutineStopped?.Invoke(stopPos);
                OnMoveroutineStoppedEvent?.Raise(stopPos);
            };
            return simpleRoutine;
        }

        private void OnValidate()
        {
            SetIntensityParams();
        }
        #endregion

        #region public methods
        [InspectorButton]
        public void SetAllToValue(float value=50f)
        {
            var _val = Mathf.Clamp(value, 0f, 100f);

            mouseMoveSpeed = _val;
            mouseRotateSpeed = _val;
            scrollSpeed = _val;
            SetIntensityParams();
        }

        [InspectorButton]
        public void ResetCameraPosition()
        {
            SpatialOrientation target = new(_startLocalPos, _startLocalRot);
            MoveTo(target);
            OnCameraReset?.Invoke();
        }

        public void MoveTo(Vector3 position, Vector3 rot)
        {
            SpatialOrientationSRZ spatialOrientationS = new(position, rot);
            MoveTo(spatialOrientationS.Get());
        }

        public void MoveTo(Transform transform)
        {
            SpatialOrientation target = new(transform.position, transform.rotation);
            MoveTo(target);
        }

        public void MoveTo(SpatialOrientation target)
        {
            _rb.isKinematic = true;
            _target = target;
            SpatialOrientation start = new SpatialOrientation(transform.position, transform.rotation);
            if (!_simpleRoutine.IsRunning)
            {
                ProgressRoutineHandler routineActionHandler = (float t) =>
                {
                    transform.SetPositionAndRotation(
                        Vector3.Lerp(start.Position, _target.Position, t),
                        Quaternion.Slerp(start.Rotation, _target.Rotation, t)
                        );
                };
                _simpleRoutine.SetParams(routineActionHandler, moveDuration);
                _simpleRoutine.StartRoutine(this);
            }
            else
            {
                Debug.LogWarning("MoveTo: Routine already running");
            }
            _rb.isKinematic = false;
        }
        #endregion
    }
}
