using UUP.CustomAttributes;
using UUP.CustomAttributes.CustomTargets;
using UUP.ScriptableObjects.Data.ObervableLists;
using System.Collections.Generic;
using UnityEngine;

namespace UUP.Common.Data.ObservableLists
{
    /// <summary>
    /// The Unity Events in the ScriptableObject based "Observable Lists" are Serialized in the Inspector but can only be assigned to other ScriptableObjects.
    /// This is the problem, we solve here: By connecting the SO-ObservableList with a MonoBehaviour-ObservableListController.
    /// This allows to "synchronize" all the functionalities of the SO-ObservableList with the MonoBehaviour-ObservableListController.
    /// This allows for example to use the UnityEvents in the MonoBehaviour-ObservableListController in the Inspector:
    ///     - Those can finally be assigned to any GameObjects in the Scene.
    /// </summary>
    /// <typeparam name="TList">The ScriptableObject based ObservableList</typeparam>
    /// <typeparam name="TData">The type parameter of T1</typeparam>
    public class ObservableListSOController<TList, TData> : MonoBehaviourT, IObservableListController<TData> 
        where TList : OberservableListSO<TData> 
    {
        [SerializeField] 
        TList observableListSO;

        public int Count => observableListSO.Count;
        public List<TData> Value => observableListSO.Value;

        public void Add(TData item)
        {
            observableListSO.Add(item);
        }

        [InspectorButton]
        public void Clear()
        {
            observableListSO.Clear();
        }

        public bool Contains(TData item)
        {
            return observableListSO.Contains(item);
        }

        public TData GetAt(int index)
        {
            return observableListSO.GetAt(index);
        }

        public int IndexOf(TData item)
        {
            return observableListSO.IndexOf(item);
        }

        public void ModifyItem(int index, TData item)
        {
            observableListSO.ModifyItem(index, item);
        }

        public void MoveItem(int oldIndex, int newIndex)
        {
            observableListSO.MoveItem(oldIndex, newIndex);
        }



        public void RemoveAt(int index)
        {
            observableListSO.RemoveAt(index);
        }

        public void Set(List<TData> items)
        {
            observableListSO.Set(items);
        }


    }
}