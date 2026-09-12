using UUP.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UUP.Extensions
{
    public static class Vector3Extension
    {
        /// <summary>
        /// Set the x value of a Vector3
        /// </summary>
        /// <param name="vector">The vector3 which is manipulated</param>
        /// <param name="x">The new x-component of the vector3</param>
        /// <returns></returns>
        public static Vector3 SetX(this Vector3 vector, float x)
        {
            return new Vector3(x, vector.y, vector.z);
        }

        /// <summary>
        /// Set the y value of a Vector3
        /// </summary>
        /// <param name="vector">The vector3 which is manipulated</param>
        /// <param name="y">The new y-component of the vector3</param>
        /// <returns></returns>
        public static Vector3 SetY(this Vector3 vector, float y)
        {
            return new Vector3(vector.x, y, vector.z);
        }

        /// <summary>
        /// Set the z value of a Vector3
        /// </summary>
        /// <param name="vector">The vector3 which is manipulated</param>
        /// <param name="y">The new z-component of the vector3</param>
        /// <returns></returns>
        public static Vector3 SetZ(this Vector3 vector, float z)
        {
            return new Vector3(vector.x, vector.y, z);
        }

        /// <summary>
        /// Set the x, y and z value of a Vector3
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vector3 Set(this Vector3 vector, float x = 0, float y = 0, float z = 0)
        {
            return new Vector3(x, y, z);
        }

        public static Vector3 AddX(this Vector3 vector, float x)
        {
            return new Vector3(vector.x + x, vector.y, vector.z);
        }

        public static Vector3 AddY(this Vector3 vector, float y)
        {
            return new Vector3(vector.x, vector.y + y, vector.z);
        }

        public static Vector3 AddZ(this Vector3 vector, float z)
        {
            return new Vector3(vector.x, vector.y, vector.z + z);
        }

        public static Vector3 Add(this Vector3 vector, float x = 0, float y = 0, float z = 0)
        {
            return new Vector3(vector.x + x, vector.y + y, vector.z + z);
        }

        public static Vector3 GetAxisVector(this Vector3 vector, AxisSelect axis)
        {
            return axis switch
            {
                AxisSelect.X => Vector3.right,
                AxisSelect.Y => Vector3.up,
                AxisSelect.Z => Vector3.forward,
                _ => Vector3.zero
            };
        }
    }
}
