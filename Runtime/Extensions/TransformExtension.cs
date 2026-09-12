using UUP.CustomDataTypes;
using System.Collections.Generic;
using UnityEngine;

namespace UUP.Extensions
{
    public static class TransformExtension
    {
        public static void SetXPos(this Transform transform, float x)
        {
            transform.position = transform.position.SetX(x);
        }

        public static void SetYPos(this Transform transform, float y)
        {
            transform.position = transform.position.SetY(y);
        }

        public static void SetZPos(this Transform transform, float z)
        {
            transform.position = transform.position.SetZ(z);
        }

        public static void SetPos(this Transform transform, float x = 0, float y = 0, float z = 0)
        {
            transform.position = new Vector3(x, y, z);
        }

        public static void SetLocalXPos(this Transform transform, float x)
        {
            transform.localPosition = transform.localPosition.SetX(x);
        }

        public static void SetLocalYPos(this Transform transform, float y)
        {
            transform.localPosition = transform.localPosition.SetY(y);
        }

        public static void SetLocalZPos(this Transform transform, float z)
        {
            transform.localPosition = transform.localPosition.SetZ(z);
        }

        public static void SetLocalPos(this Transform transform, float x = 0, float y = 0, float z = 0)
        {
            transform.localPosition = new Vector3(x, y, z);
        }

        public static void SetXRot(this Transform transform, float x)
        {
            transform.rotation = Quaternion.Euler(x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }

        public static void SetXRotLocal(this Transform transform, float x)
        {
            transform.localRotation = Quaternion.Euler(x, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);
        }

        public static void SetYRot(this Transform transform, float y)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, y, transform.rotation.eulerAngles.z);
        }

        public static void SetYRotLocal(this Transform transform, float y)
        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, y, transform.localRotation.eulerAngles.z);
        }

        public static void SetZRot(this Transform transform, float z)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, z);
        }

        public static void SetZRotLocal(this Transform transform, float z)
        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, z);
        }

        public static void SetRot(this Transform transform, float x = 0, float y = 0, float z = 0)
        {
            transform.rotation = Quaternion.Euler(x, y, z);
        }

        public static void SetRot(this Transform transform, Vector3 eulerAngles)
        {
            transform.rotation = Quaternion.Euler(eulerAngles);
        }

        public static void SetRot(this Transform transform, Quaternion rotation)
        {
            transform.rotation = rotation;
        }

        public static void SetLocalRot(this Transform transform, float x = 0, float y = 0, float z = 0)
        {
            transform.localRotation = Quaternion.Euler(x, y, z);
        }

        public static void SetLocalRot(this Transform transform, Vector3 eulerAngles)
        {
            transform.localRotation = Quaternion.Euler(eulerAngles);
        }

        public static void SetLocalRot(this Transform transform, Quaternion rotation)
        {
            transform.localRotation = rotation;
        }

        public static void SetSpatialOrientation(this Transform transform, SpatialOrientation spatialOrientation)
        {
            transform.position = spatialOrientation.Position;
            transform.rotation = spatialOrientation.Rotation;
        }

        public static void SetLocalSpatialOrientation(this Transform transform, SpatialOrientation spatialOrientation)
        {
            transform.localPosition = spatialOrientation.Position;
            transform.localRotation = spatialOrientation.Rotation;
        }

        /// <summary>
        /// Returns the first parent-Transform according to a specified tag
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="tag">the specified tag of the parent which wil be searched for</param>
        /// <returns></returns>
        public static Transform FindFirstParentWithTag(this Transform transform, string tag)
        {
            Transform parent = transform.parent;

            while (parent != null)
            {
                if (parent.CompareTag(tag))
                    return parent;

                parent = parent.parent;
            }

            return null;
        }

        public static List<Transform> GetActiveChildren(this Transform transform)
        {
            List<Transform> children = new List<Transform>();
            foreach (Transform child in transform)
            {
                if (child.gameObject.activeSelf)
                {
                    children.Add(child);
                }
            }
            return children;
        }

        public static List<Transform> GetNonActiveChildren(this Transform transform)
        {
            List<Transform> children = new List<Transform>();
            foreach (Transform child in transform)
            {
                if (!child.gameObject.activeSelf)
                {
                    children.Add(child);
                }
            }
            return children;
        }

        public static List<Transform> GetChildren(this Transform transform)
        {
            List<Transform> children = new List<Transform>();
            foreach (Transform child in transform)
            {
                children.Add(child);
            }
            return children;
        }

        public static void PerformActionOnChildren(this Transform transform, System.Action<Transform> action)
        {
            // avoid foreach for better performance because foreach creates a new enumerator object which needs to be garbage collected
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                action(transform.GetChild(i));
            }
        }

        public static void ActivateAllChildren(this Transform transform)
        {
            transform.PerformActionOnChildren((child) => child.gameObject.SetActive(true));
        }

        public static void DeactivateAllChildren(this Transform transform)
        {
            transform.PerformActionOnChildren((child) => child.gameObject.SetActive(false));
        }

        public static string GetHierarchyPath(this Transform transform)
        {
            List<string> path = new List<string>();

            while (transform != null)
            {
                path.Add(transform.name);
                transform = transform.parent;
            }

            path.Reverse();
            return string.Join("/", path);
        }

        public static void DebugState(this Transform transform)
        {
            Debug.Log(transform.GetHierarchyPath());
            Debug.Log("Position: " + transform.position);
            Debug.Log("Rotation: " + transform.rotation.eulerAngles);
            Debug.Log("Scale: " + transform.localScale);
            Debug.Log("Local Position: " + transform.localPosition);
            Debug.Log("Local Rotation: " + transform.localRotation.eulerAngles);
        }

    }
}
