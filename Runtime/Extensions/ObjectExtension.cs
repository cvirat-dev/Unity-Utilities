using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UUP.Extensions
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Check if the object is null according to Unity's custom null handling
        /// This approach helps enforce Unity's behavior explicitly and avoids confusion between "== null" and "is null"
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNull(this Object obj)
        {
            return obj == null;
        }
    }
}
