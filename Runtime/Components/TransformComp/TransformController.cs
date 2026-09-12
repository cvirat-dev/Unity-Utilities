using UUP.Extensions;
using UnityEngine;

namespace UUP.Components
{
    public class TransformController : MonoBehaviour
    {
        public void SetXPosLocal(float val)
        {
            transform.SetLocalXPos(val);
        }

        public void SetXPosWorld(float val)
        {
            transform.SetXPos(val);
        }

        public void SetYPosLocal(float val)
        {
            transform.SetLocalYPos(val);
        }

        public void SetYPosWorld(float val)
        {
            transform.SetYPos(val);
        }

        public void SetZPosLocal(float val)
        {
            transform.SetLocalZPos(val);
        }

        public void SetZPosWorld(float val)
        {
            transform.SetZPos(val);
        }

        public void SetPositionLocal(Vector3 pos)
        {
            transform.SetLocalPos(pos.x, pos.y, pos.z);
        }

        public void SetPositionWorld(Vector3 pos)
        {
            transform.SetPos(pos.x, pos.y, pos.z);
        }

        public void SetXRotLocal(float val)
        {
            transform.SetXRotLocal(val);
        }

        public void SetXRotWorld(float val)
        {
            transform.SetXRot(val);
        }

        public void SetYRotLocal(float val)
        {
            transform.SetYRot(val);
        }

        public void SetYRotWorld(float val)
        {
            transform.SetYRotLocal(val);
        }

        public void SetZRotLocal(float val)
        {
            transform.SetZRot(val);
        }

        public void SetZRotWorld(float val)
        {
            transform.SetZRotLocal(val);
        }

        public void SetRotationLocal(Vector3 eulerRot)
        {
            transform.SetLocalRot(eulerRot);
        }

        public void SetRotationLocal(Quaternion rot)
        {
            transform.localRotation = rot;
        }

        public void SetRotationWorld(Quaternion rot)
        {
            transform.rotation = rot;
        }

        public void SetRotationWorld(Vector3 eulerRot)
        {
            transform.SetRot(eulerRot);
        }

        public void SetScale(Vector3 scale)
        {
            transform.localScale = scale;
        }

        public void SetScale(float x, float y, float z)
        {
            transform.localScale = new Vector3(x, y, z);
        }

        public void SetXScale(float x)
        {
            transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
        }

        public void SetYScale(float y)
        {
            transform.localScale = new Vector3(transform.localScale.x, y, transform.localScale.z);
        }

        public void SetZScale(float z)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, z);
        }
    }
}
