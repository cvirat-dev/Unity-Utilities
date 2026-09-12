using System;
using System.Collections.Generic;
using UnityEngine;

namespace UUP.Extensions
{
    public static class GameObjectExtension
    {
        /// <summary>
        /// Activate or deactivate the game object based on its current state
        /// </summary>
        /// <param name="gameObject"></param>
        public static void AdaptiveActivation(this GameObject gameObject)
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        /// <summary>
        /// Toggles the active states of two GameObjects so that only one of them is active at a time.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="gameObject2"></param>
        public static void BinaryActivation(this GameObject gameObject, GameObject gameObject2)
        {
            if (gameObject.activeSelf)
            {
                gameObject.SetActive(false);
                gameObject2.SetActive(true);
            }
            else
            {
                gameObject.SetActive(true);
                gameObject2.SetActive(false);
            }
        }

        /// <summary>
        /// Do not judge the parent please, just let him cook :')
        /// </summary>
        /// <param name="gameObject"></param>
        public static void DestroyAllChildren(this GameObject gameObject)
        {
            foreach (Transform child in gameObject.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        public static void DestroyChildren(this GameObject gameObject, Func<GameObject, bool> condition)
        {
            foreach (Transform child in gameObject.transform)
            {
                if (condition(child.gameObject))
                {
                    GameObject.Destroy(child.gameObject);
                }
            }
        }

        public static T GetOrAdd<T>(this GameObject gameObject) where T : Component
        {
            T component = gameObject.GetComponent<T>();
            if (component == null)
            {
                component = gameObject.AddComponent<T>();
            }
            return component;
        }

        public static GameObject[] GetAllChildren(this GameObject gameObject)
        {
            List<GameObject> children = new List<GameObject>();
            foreach (Transform child in gameObject.transform)
            {
                children.Add(child.gameObject);
            }
            return children.ToArray();
        }

        public static GameObject[] SelectChildren(this GameObject gameObject, Func<GameObject, bool> condition)
        {
            List<GameObject> children = new List<GameObject>();
            foreach (Transform child in gameObject.transform)
            {
                if (condition(child.gameObject))
                {
                    children.Add(child.gameObject);
                }
            }
            return children.ToArray();
        }

        public static void ActivateAllChildren(this GameObject gameObject)
        {
            gameObject.transform.ActivateAllChildren();
        }

        public static void DeactivateAllChildren(this GameObject gameObject)
        {
            gameObject.transform.DeactivateAllChildren();
        }

        public static string GetHierarchyPath(this GameObject gameObject)
        {
            return gameObject.transform.GetHierarchyPath();
        }

        public static void DebugState(this GameObject gameObject)
        {
            Debug.Log(gameObject.name);
            string path = gameObject.GetHierarchyPath();
            Debug.Log(path);
        }
    }
}
