using UUP.CustomDataTypes;
using UUP.CustomDataTypes.Serializables;
using UUP.Extensions;
using UnityEngine;

namespace UUP
{
    /// <summary>
    /// A general utility controller for GameObjects
    /// </summary>
    public class GameObjectUtilityController : MonoBehaviour
    {
        #region PositionControll
        public void SetPositionLocal(Vector3 position)
        {
            transform.localPosition = position;
        }

        public void SetPositionLocal(SpatialOrientation spatialOrientation)
        {
            transform.localPosition = spatialOrientation.Position;
            transform.localRotation = spatialOrientation.Rotation;
        }

        public void SetPositionLocal(SpatialOrientationSRZ spatialOrientationS)
        {
            transform.localPosition = spatialOrientationS.Get().Position;
            transform.localRotation = spatialOrientationS.Get().Rotation;
        }

        public void SetPositionWorld(Vector3 position)
        {
            transform.position = position;
        }

        public void SetPositionWorld(SpatialOrientation spatialOrientation)
        {
            transform.position = spatialOrientation.Position;
            transform.rotation = spatialOrientation.Rotation;
        }

        public void SetPositionWorld(SpatialOrientationSRZ spatialOrientationS)
        {
            transform.position = spatialOrientationS.Get().Position;
            transform.rotation = spatialOrientationS.Get().Rotation;
        }
        #endregion

        public void SetName(string name)
        {
            gameObject.name = name;
        }

        public void ActivateAllChilds(bool activate)
        {
            if (activate)
            {
                this.gameObject.ActivateAllChildren();
            }
            else
            {
                this.gameObject.DeactivateAllChildren();
            }
        }

        public void ActivateAllChilds()
        {
            ActivateAllChilds(true);
        }

        public void DeactivateAllChilds()
        {
            ActivateAllChilds(false);
        }

        public void TrySetColor(Color color)
        {
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = color;
            }
            else
            {
                Debug.LogWarning($"No Renderer found on {gameObject.name}");
            }
        }

        public void TryStartAnimation(string animationName)
        {
            if (TryGetComponent(out Animator animator))
            {
                animator.RestartAnimation(animationName);
            }
            else
            {
                Debug.LogWarning($"No Animator found on {gameObject.name}");
            }
        }

    }
}
