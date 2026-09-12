using UUP.ScriptableObjects.Data.ObervableLists;
using UUP.ScriptableObjects.Data.Variables;
using UnityEngine;

namespace Assets._Scripts.CameraObservableList
{
    public class UiLabelsManager : MonoBehaviour
    {
        [SerializeField]
        private StringVariableSO currentPositionIndexMssg;

        [SerializeField]
        private StringVariableSO numberOfDefinedPositionsMssg;

        [SerializeField]
        private SpatialOrientationObservableListSO cameraPositionsRecord;

        [SerializeField]
        private IntVariableSO currentCameraPosition;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // One time only: manually set the current location text to the first index of the camera positions record
            OnRegisterChange();
            OnCameraPositionChange(-1);
        }

        private void OnEnable()
        {
            cameraPositionsRecord.OnListChanged += OnRegisterChange;
            currentCameraPosition.OnValueSet += OnCameraPositionChange;
        }

        private void OnDisable()
        {
            cameraPositionsRecord.OnListChanged -= OnRegisterChange;
            currentCameraPosition.OnValueSet -= OnCameraPositionChange;
        }

        private void OnRegisterChange()
        {
            numberOfDefinedPositionsMssg.Value = $"{cameraPositionsRecord.Count} positions defined";
        }

        private void OnCameraPositionChange(int index)
        {
            var uiIndex = index + 1;

            if (uiIndex == 0)
            {
                currentPositionIndexMssg.Value = "No Position currently set";
                return;
            }
            else
            {
                currentPositionIndexMssg.Value = $"Current Position Index: {uiIndex}";
            }

        }
    }
}