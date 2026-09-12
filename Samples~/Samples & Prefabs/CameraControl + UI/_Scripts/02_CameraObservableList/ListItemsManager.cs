using UUP.CustomDataTypes;
using UUP.Extensions;
using UUP.ScriptableObjects.Data.ObervableLists;
using UUP.ScriptableObjects.GameEvents.Serialized;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Assets._Scripts.CameraObservableList.ListItemController;

namespace Assets._Scripts.CameraObservableList
{
    public class ListItemsManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject listItemPrefab;
        [SerializeField]
        private SpatialOrientationObservableListSO cameraPositions;
        [SerializeField]
        private List<ItemData> itemsData = new List<ItemData>();

        private GameObject newItem;
        private Dictionary<GameObject, ListItemController> itemsDictionary = new Dictionary<GameObject, ListItemController>();

        public IntGameEvent OnPositionChangeGE;

        private void Awake()
        {
            if (cameraPositions != null)
            {
                cameraPositions.OnItemAdded += OnItemAdded;
                cameraPositions.OnCleared += OnListCleared;
            }

            // Remove all the children of this Gameobject
            //foreach (Transform child in transform)
            //{
            //    Destroy(child.gameObject);
            //}
            gameObject.DestroyAllChildren();
        }

        private void OnDisable()
        {
            if (cameraPositions != null)
            {
                cameraPositions.OnItemAdded -= OnItemAdded;
                cameraPositions.OnCleared -= OnListCleared;
            }
        }

        private void OnItemAdded(int index, SpatialOrientation itemData)
        {
            // Create a new item and set its data
            newItem = Instantiate(listItemPrefab, transform);
            var listItemController = newItem.GetComponent<ListItemController>();
            listItemController.OnInit(itemData, index);

            // Set the name of the item
            string newText = "Camera Position " + transform.childCount;
            newItem.name = newText;
            listItemController.SetText(newText);

            // Add the item data to the list
            var itemDataValue = listItemController.ItemDataF;
            itemsData.Add(itemDataValue);

            // Register the event
            listItemController.OnSelected += HandleItemSelectionState;

            // Add the item to the dictionary
            itemsDictionary.Add(newItem, listItemController);
        }

        private void OnListCleared()
        {
            itemsData.Clear();
            
            foreach (var keyValueItem in itemsDictionary)
            {
                // Deregister the event
                keyValueItem.Value.OnSelected -= HandleItemSelectionState;

                Destroy(keyValueItem.Key);
            }

            itemsDictionary.Clear();
        }

        public void RemoveLastItem()
        {
            if (itemsDictionary.Count > 0)
            {
                // Deregister the event
                var lastPair = itemsDictionary.Last();
                lastPair.Value.OnSelected -= HandleItemSelectionState;

                itemsDictionary.Remove(lastPair.Key);
                Destroy(lastPair.Key);
            }
        }

        public void RemoveItem(int index)
        {
            if(index < 0 || index >= itemsDictionary.Count)
            {
                Debug.LogWarning("Index out of range");
                return;
            }

            // Deregister the event
            var itemToRemove = itemsDictionary.ElementAt(index);
            itemToRemove.Value.OnSelected -= HandleItemSelectionState;

            itemsDictionary.Remove(itemToRemove.Key);
            Destroy(itemToRemove.Key);

            // Update the names of the items
            for (int i = 0; i < itemsDictionary.Count; i++)
            {
                var gameObject = itemsDictionary.ElementAt(i).Key;
                var listItemController = itemsDictionary.ElementAt(i).Value;

                string newText = "Camera Position " + (i + 1);
                gameObject.name = newText;
                listItemController.SetText(newText);
            }
        }

        public void DeselectAll()
        {
            foreach (var keyValuePair in itemsDictionary)
            {
                keyValuePair.Value.DeSelectItem();
            }
        }

        private void HandleItemSelectionState(ListItemController listItemController)
        {
            var selectedIndex = listItemController.ItemDataF.Index;

            foreach (var keyValuePair in itemsDictionary)
            {
                ListItemController itemController = keyValuePair.Value;
                var itemIndex = itemController.ItemDataF.Index;

                if (itemIndex != selectedIndex)
                {
                    itemController.DeSelectItem();
                }
            }

            if (listItemController.ItemDataF.IsSelected)
            {
                OnPositionChangeGE.Raise(selectedIndex);
            }
        }
    }
}