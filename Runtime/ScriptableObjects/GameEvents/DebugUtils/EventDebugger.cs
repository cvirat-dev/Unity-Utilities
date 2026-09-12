using UUP.CustomDataTypes;
using UUP.Extensions;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.DebugUtils
{
    /// <summary>
    /// A simple MonoBehaviour that can be attached to a GameObject to listen to GameEvents and log the data they pass.
    /// </summary>
    public class EventDebugger : MonoBehaviour
    {
        public void DebugEvent()
        {
            Debug.Log("Empty event received");
        }

        public void DebugEvent(object data)
        {
            Debug.Log($"Data received: {data}, of type : {data.GetType()}");
        }

        public void DebugEvent(int data)
        {
            Debug.Log(data);
        }

        public void DebugEvent(float data)
        {
            Debug.Log(data);
        }

        public void DebugEvent(string data)
        {
            Debug.Log(data);
        }

        public void DebugEvent(bool data)
        {
            Debug.Log(data);
        }

        public void DebugEvent(Vector2 data)
        {
            Debug.Log(data);
        }

        public void DebugEvent(Vector3 data)
        {
            Debug.Log(data);
        }

        public void DebugEvent(Vector4 data)
        {
            Debug.Log(data);
        }

        public void DebugEvent(Color data)
        {
            Debug.Log(data);
        }

        public void DebugEvent(Color32 data)
        {
            Debug.Log(data);
        }

        public void DebugEvent(GameObject data)
        {
            data.DebugState();
        }

        public void DebugEvent(Transform data)
        {
            data.DebugState();
        }

        public void DebugEvent(SpatialOrientation data)
        {
            data.DebugState();
        }

        // Add more overloads as needed
    }
}
