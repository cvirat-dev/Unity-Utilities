
using System.Collections.Generic;
using System;
using UnityEngine;
using UUP.ScriptableObjects.Data.Variables.Arrays;
using UUP.Common.Data.Variables;

namespace UUP.Common.Data.Arrays
{
    /// <summary>
    /// Manages event subscription and unsubscription for an array of variables.
    /// </summary>
    /// <typeparam name="TVariable"></typeparam>
    /// <typeparam name="TData"></typeparam>
    public class EventAttachmentManager<TVariable, TData> where TVariable : INotifiedVariable<TData>
    {
        private Dictionary<int, TVariable> _variableIndexMap; // Map variables to their index in the array
        private Dictionary<int, Action<TData>> _newValueActionMap; // Map index to the action that will be called when the value changes

        private NotifiedArrayBaseSO<TData> _base;
        private TVariable[] _array;

        public EventAttachmentManager(NotifiedArrayBaseSO<TData> comp, TVariable[] array)
        {
            _base = comp ?? throw new ArgumentNullException(nameof(comp));
            _array = array ?? throw new ArgumentNullException(nameof(array));

            _variableIndexMap = new Dictionary<int, TVariable>();
            _newValueActionMap = new Dictionary<int, Action<TData>>();
        }

        /// <summary>
        /// This method will attach the handlers to the variables in the array.
        /// </summary>
        /// <param name="OnNewValueHandler"></param>
        public void AttachHandlers(NewValueHandler<TData> OnNewValueHandler)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == null)
                {
                    Debug.LogWarning($"{_base.name} : Missing Reference in ArraySO at index {i}. Skipping");
                    continue;
                }

                // Store the variable and index
                int index = i; // Need to store the index in a separate variable to avoid Lambda capture issues
                var variable = _array[index];
                _variableIndexMap.Add(index, variable);

                // Create and store the handler
                void newValueHandler(TData newValue) => OnNewValueHandler(index, newValue);

                variable.OnValueSet += newValueHandler;

                _newValueActionMap.Add(index, newValueHandler);
            }
        }

        public void DetachHandlers()
        {
            foreach (var kvp in _variableIndexMap)
            {
                int index = kvp.Key;
                var variable = kvp.Value;

                if (variable == null)
                {
                    Debug.LogWarning("Null variable in array. Skipping");
                    continue;
                }

                var newValueHandler = _newValueActionMap[index];
                variable.OnValueSet -= newValueHandler;
            }
            _variableIndexMap.Clear();
            _newValueActionMap.Clear();
        }

        public string GetAttachementInformations()
        {
            string info1 = $"{nameof(_variableIndexMap)} has {_variableIndexMap.Count} variables / indices";
            string info2 = $"{nameof(_newValueActionMap)} has {_newValueActionMap.Count} actions";
            return $"{info1}\n{info2}";
        }
    }
}
