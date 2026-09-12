using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UUP.Extensions;

namespace UUP.Utilities.GameObjectUtils
{
    /// <summary>
    /// Utilities for basic operations related to arrays of GameObjects.
    /// </summary>
    public static class ArrayUtils
    {
        /// <summary>
        /// Activates a single GameObject in an array of GameObjects based on the provided index.
        /// </summary>
        /// <param name="gameObjects"></param>
        /// <param name="index"></param>
        public static void ActivateGameObject(GameObject[] gameObjects, int index)
        {
            if (index >= 0 && index < gameObjects.Length)
            {
                gameObjects[index].SetActive(true);
            }
            else
            {
                Debug.LogError("Index out of range");
                Debug.Break();
            }
        }

        /// <summary>
        /// Deactivates a single GameObject in an array of GameObjects based on the provided index.
        /// </summary>
        /// <param name="gameObjects"></param>
        /// <param name="index"></param>
        public static void DeactivateGameObject(GameObject[] gameObjects, int index)
        {
            if (index >= 0 && index < gameObjects.Length)
            {
                gameObjects[index].SetActive(false);
            }
            else
            {
                Debug.LogError("Index out of range");
                Debug.Break();
            }
        }

        /// <summary>
        /// Toggles the active state of GameObjects in a loop.
        /// Sets the currently active GameObject to false and the next one to true.
        /// If no active GameObject is found, sets the first GameObject in the array to true.
        /// </summary>
        /// <param name="gameObjects">array of gameobjects</param>
        public static void ToggleActiveGameObject(GameObject[] gameObjects)
        {
            GameObject activeObject = null;

            /** <summary> Find the current active gameobject </summary> */
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

                // Find the index of the active object in the array
                int currentIndex = Array.IndexOf(gameObjects, activeObject);

                // Calculate the index of the next object
                int nextIndex = (currentIndex + 1) % gameObjects.Length;

                // Set the next object to true
                gameObjects[nextIndex].SetActive(true);
            }
            else if (gameObjects.Length > 0)
            {
                // If no active object was found, set the first object to true
                gameObjects[0].SetActive(true);
            }
        }

        /// <summary>
        /// Sets the active state of game objects from an array based on the provided index.
        /// This method takes an array of game objects, `gameobjectArr`, and an index, `activeObjectIndex`, and sets the active state of the game objects based on the index. 
        /// Each game object in the array will be activated if its index matches the provided `activeObjectIndex`, and deactivated otherwise.
        /// <param name="gameObjectArr">array of gameobjects</param>
        /// <param name="activeObjectIndex">index of the gameobject which should be set active</param>
        public static void SetSingleActive(GameObject[] gameObjectArr, int activeObjectIndex)
        {
            int arrayLength = gameObjectArr.Length;
            for (int i = 0; i < arrayLength; i++)
            {
                gameObjectArr[i].SetActive(i == activeObjectIndex);
            }
        }

        /// <summary>
        /// Toggles the visibility of a single object in the provided array while hiding the rest.
        /// </summary>
        /// <param name="gameObjectArr">array of gameobjects</param>
        /// <param name="index">index of the gameobject which should be toggled on / off</param>
        public static void ToggleSingleObjectAndHideRest(GameObject[] gameObjectArr, int index)
        {
            for (int i = 0; i < gameObjectArr.Length; i++)
            {
                if (i == index)
                {
                    gameObjectArr[i].AdaptiveActivation();
                }

                else
                {
                    gameObjectArr[i].SetActive(false);
                }
            }
        }

        /// <summary>
        /// Toggles the visibility of a single gameobject in the provided array
        /// </summary>
        /// <param name="gameObjectarr">array of gameobjects</param>
        /// <param name="index">index of the gameobject which sould be toggled on / off </param>
        public static void ToggleSingle(GameObject[] gameObjectarr, int index)
        {
            gameObjectarr[index].AdaptiveActivation();
        }

        /// <summary>
        /// Toggles the active state of gameobjects iteratively based on a counter.
        /// The method iterates through the array and activates the gameobject at the current counter value while deactivating all other game objects. 
        /// The counter iterates over the array length.
        /// This function is useful when you want to toggle the active state of multiple game objects in an iterative manner, such as cycling through a sequence of objects. 
        /// <param name="counter">array of gameobjects</param>
        /// <param name="gameObjectArr">reference to an integer counter</param>
        public static void ToggleObjectsIteratively(GameObject[] gameObjectArr, ref int counter)
        {
            if (counter < gameObjectArr.Length)
            {
                SetSingleActive(gameObjectArr, counter);
            }

            else
            {
                counter = 0;
                SetSingleActive(gameObjectArr, counter);
            }

            counter++;
        }

        /// <summary>
        /// Toggles the active state of gameobjects inside arrays iteratively based on a counter.
        /// Memory function: When switching between keys (gameobject-array), the script remembers the last "state" so that the iteration does not start again from the beginning. 
        /// Exception: "Empty-Gameobject" was the last active element. Note: The empty-gameobject must have the tag "Empty"!
        /// It iteratively toggles the active state of the gameobjects based on the counter stored in the dictionary. If the counter is less than the length of the game object array, the method activates the game object at the corresponding index and increments the counter. If the counter exceeds the array length, all gameobjects in the array are deactivated, and the counter is reset to 0.
        /// By using a dictionary to store the counter, it allows you to keep track of the current iteration state for a specific array of game objects.
        /// <param name="activeObjArr">array of gameobjects</param>
        /// <param name="myDict">dictionary which maps the gameobject-array to an integer counter</param>
        public static void ToggleObjectsIterativelyDict(GameObject[] activeObjArr, Dictionary<GameObject[], int> myDict, ref int memoryCounter)
        {
            /** <summary> Retrieves the int-value associated with the activeObjArr-key in the myDict dictionary </summary> */
            memoryCounter = myDict[activeObjArr];

            /** <summary>  Check if the active-object-array contains an object with the tag "Empty" </summary> */
            bool isEmptyObjectActive = activeObjArr[memoryCounter].CompareTag("Empty");

            /** <summary> Deactivates all gameobject inside the other gameobject-arrays based on the provided active array and dictionary </summary> */
            foreach (GameObject[] gameObjArr in myDict.Keys.ToArray())
            {
                if (gameObjArr != activeObjArr)
                {
                    DeactivateAll(gameObjArr);

                    if (!isEmptyObjectActive)
                    {
                        /** <summary> Memory function </summary> */
                        myDict[gameObjArr] = memoryCounter;
                    }

                    else
                    {
                        myDict[gameObjArr] = 0;
                    }
                }
            }

            SetSingleActive(activeObjArr, myDict[activeObjArr]);

            myDict[activeObjArr]++;

            if (myDict[activeObjArr] >= activeObjArr.Length)
            {
                myDict[activeObjArr] = 0;
            }
        }

        /// <summary>
        /// Switches between rows in a 2D array of GameObjects based on the presence of active objects.
        /// Deactivates all objects in the current active row and activates a specific index in the next row.
        /// </summary>
        /// <param name="twoDimArray">2D-Array of gameobject</param>
        public static void ArraySwitcher2D(GameObject[][] twoDimArray)
        {
            int rows = twoDimArray.GetLength(0);
            int activeRow = 0;
            int index = 0;

            /** <summary> Check if a row has active gameobjects. If one is found: save the row-index and active-object-index and deactivate all objects </summary> */
            for (int i = 0; i < rows; i++)
            {
                if (IsAnyActive(twoDimArray[i]))
                {
                    activeRow = i;
                    index = IndexOfFirstActiveObjectInArray(twoDimArray[activeRow]);
                    DeactivateAll(twoDimArray[activeRow]);
                    break;
                }
            }

            // Reset activeRow to 0 if it was the last row
            if (activeRow == rows - 1)
            {
                activeRow = 0;
            }

            // Else: iterate ( activeRow ++)
            else
            {
                activeRow++;
            }

            // Activate the specific index of the next row
            SetSingleActive(twoDimArray[activeRow], index);
        }

        /// <summary>
        /// Activate all the elements inside a gameobject-array.
        /// </summary>
        /// <param name="gameobjectArr">Any gameobject-array</param>
        public static void ActivateAll(GameObject[] gameobjectArr)
        {
            foreach (GameObject obj in gameobjectArr)
            {
                obj.SetActive(true);
            }
        }

        /// <summary>
        /// Deactivate all the elements inside a gameobject-array
        /// </summary>
        /// <param name="gameObjectArr">gameobject-array</param>
        public static void DeactivateAll(GameObject[] gameObjectArr)
        {
            foreach (GameObject obj in gameObjectArr)
            {
                obj.SetActive(false);
            }
        }

        /// <summary>
        /// Checks if there is an active gameobject in an given arrays.
        /// If yes, returns true. If no, returns false.
        /// </summary>
        /// <param name="gameObjectArr">True if any active object found in array. Else, false. </param>
        public static bool IsAnyActive(GameObject[] gameObjectArr)
        {
            bool activeObjFound = false;

            foreach (GameObject obj in gameObjectArr)
            {
                if (obj.activeSelf)
                {
                    activeObjFound = true;
                    break;
                }
            }

            return activeObjFound;
        }

        /// <summary>
        /// Retrieves the index of the first active object in an array of GameObjects
        /// </summary>
        /// <param name="gameObjectArr"></param>
        /// <returns></returns>
        public static int IndexOfFirstActiveObjectInArray(GameObject[] gameObjectArr)
        {
            int value = 0;

            for (int i = 0; i < gameObjectArr.Length; i++)
            {
                if (gameObjectArr[i].activeSelf)
                {
                    value = i;
                    break;
                }
            }

            return value;
        }

        /// <summary>
        /// Toggles the state of a whole gameobject-array
        /// If all array-elements already active: set all to inactive
        /// if at least one inactive: set all to active
        /// </summary>
        /// <param name="gameObjectArr">Gameobject array</param>
        public static void ToggleAll(GameObject[] gameObjectArr)
        {
            bool allActive = AreAllActive(gameObjectArr);

            if (allActive)
            {
                DeactivateAll(gameObjectArr);
            }

            else
            {
                ActivateAll(gameObjectArr);
            }
        }

        /// <summary>
        /// Checks if all GameObjects in the given array are active
        /// </summary>
        /// <param name="gameObjectArr">True if all gameobjects are active</param>
        /// <returns></returns>
        public static bool AreAllActive(GameObject[] gameObjectArr)
        {
            bool allObjectsActive = true;

            foreach(GameObject obj in gameObjectArr)
            {
                if (!obj.activeSelf)
                {
                    allObjectsActive = false;
                    break;
                }
            }

            return allObjectsActive;
        }

        /// <summary>
        /// Returns true if the given array contains at least one null element
        /// </summary>
        /// <param name="gameObjectArr"></param>
        /// <returns></returns>
        public static bool ContainsNullElement(GameObject[] gameObjectArr)
        {
            bool containsNull = false;

            foreach (GameObject obj in gameObjectArr)
            {
                if (obj == null)
                {
                    containsNull = true;
                    break;
                }
            }

            return containsNull;
        }

        public static void ActivateIf(GameObject[] gameObjectArr, Func<GameObject, bool> condition)
        {
            foreach (GameObject obj in gameObjectArr)
            {
                obj.SetActive(condition(obj));
            }
        }

        public static void DeactivateIf(GameObject[] objects, Func<GameObject, bool> condition)
        {
            foreach (GameObject obj in objects)
            {
                obj.SetActive(!condition(obj));
            }
        }
    }

}