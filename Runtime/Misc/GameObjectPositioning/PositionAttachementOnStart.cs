using UUP.Enums;
using UnityEngine;

namespace UUP.Misc.GameObjectPositioning
{
    /// <summary>
    /// Allows to "attach" a gameobject to the transform of another Gameobject at start().
    /// Example case: attach XR-Origin-Camera-Gameobject to a specific "Masskonzept"-Gameobject.
    /// </summary>
    /// 
    public class PositionAttachementOnStart : MonoBehaviour
    {
        [SerializeField] private WorldType attachmentType;
        [SerializeField] private Transform targetObject; 

        private void Start()
        {
            if(attachmentType == WorldType.Local)
            {
                AttachToLocalPosition();
            }

            else
            {
                AttachToGlobalPosition();
            }
        }

        private void AttachToGlobalPosition()
        {
            transform.localPosition = targetObject.position;
        }

        private void AttachToLocalPosition()
        {
            transform.localPosition = targetObject.localPosition;
        }
    }
}
