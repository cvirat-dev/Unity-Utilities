using System.Collections.Generic;
using UnityEngine;

namespace UUP.Utilities.GameObjectUtils
{
    /// <summary>
    /// This class contains static methods (utilities) for basic operations on GameObject-Lists
    /// </summary>
    public static class ListUtils
    {
        /// <summary>
        /// Toggles the active state of a single game object.
        /// </summary>
        /// <param name="gameObject">Gameobject to be toggled</param>     
        public static void SimpleToggle(GameObject gameObject)
        {
            if (gameObject.activeSelf)
            {
                gameObject.SetActive(false);
            }

            else
            {
                gameObject.SetActive(true);
            }
        }
        
        
        /// <summary>
        /// Sets all gameobjects in the list to inactive.
        /// </summary>
        /// <param name="gameObjects">A List of GameObjects</param>  
        public static void DeactivateAllGameobjects(List<GameObject> gameobjects)
        {
            foreach(GameObject obj in gameobjects)
            {
                obj.SetActive(false);
            }
        }

        /// <summary>
        /// Sets all gameobjects in the list to active.
        /// </summary>
        /// <param name="gameObjects">A List of GameObjects</param>  
        public static void ActivateAllGameobjects(List<GameObject> gameobjects)
        {
            foreach (GameObject obj in gameobjects)
            {
                obj.SetActive(true);
            }
        }

        /// <summary>
        /// If any GameObject is currently active, it will be deactivated, and the next GameObject in the list will be activated. 
        /// If no GameObjects are active, the first GameObject in the list will be activated.
        /// </summary>
        /// <param name="gameObjects">A List of GameObjects to toggle the active state for.</param>  
        public static void ToggleActiveGameObject(List<GameObject> gameObjects)
        {
            GameObject activeObject = null;

            // Find the currently active GameObject
            foreach (GameObject obj in gameObjects)
            {
                if (obj.activeSelf)
                {
                    activeObject = obj;
                    break;
                }
            }

            if (activeObject != null)
            {
                // Set the current active object to false
                activeObject.SetActive(false);

                // Find the index of the active object in the list
                int currentIndex = gameObjects.IndexOf(activeObject);

                // Calculate the index of the next object
                int nextIndex = (currentIndex + 1) % gameObjects.Count;

                // Set the next object to true
                gameObjects[nextIndex].SetActive(true);
            }

            else if (gameObjects.Count > 0)
            {
                // If no active object was found, set the first object to true
                gameObjects[0].SetActive(true);
            }
        }

        /// <summary>
        /// Returns the index of the active gameobject (the first one which has been found active)
        /// WARNING: This method assumes there is only one active Gameobject in the list!!!
        /// </summary>
        /// <param name="gameObjects">List of gameobjects</param>
        /// <returns></returns>
        public static int ReturnIndexOfFirstActiveGameobject(List<GameObject> gameObjects)
        {
            int index = 0;
            int i = 0;
            foreach (GameObject obj in gameObjects)
            {
                if (obj.activeSelf)
                {
                    index = i;
                    break;
                }

                i++;
            }

            return index;
        }

        /// <summary>
        /// Sets the active state of game objects from an list based on the provided index.
        /// One gameobject in the list will be activated if its index matches the provided `activeObjectIndex`
        /// The other ones will be deactivated
        /// <param name="gameObjects">list of game objects</param>
        /// <param name="activeObjectIndex">Index of gameobject which should be set active</param>
        public static void SetActiveObjectFromList(List<GameObject> gameObjects, int activeObjectIndex)
        {
            int length = gameObjects.Count;

            for (int i = 0; i < length; i++)
            {
                gameObjects[i].SetActive(i == activeObjectIndex);
            }
        }
    }

}

