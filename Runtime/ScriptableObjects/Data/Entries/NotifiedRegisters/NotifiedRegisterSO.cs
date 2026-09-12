using UUP.Common.Data.Arrays;
using UUP.Common.Data.Entries;
using UUP.Common.Data.Entries.NotifiedRegisters;
using UUP.CustomAttributes;
using UUP.Debugging;
using UUP.ScriptableObjects.Data.Variables.Arrays;
using UUP.Utilities.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace UUP.ScriptableObjects.Data.Entries.NotifiedRegisters
{
    /// <summary>
    /// A Register is a collection of Entries <see cref="EntrySO{T}"/> which can be set at runtime.
    /// Same concept as <see cref="NotifiedArraySO{TVariable, TData}"/> but based on Entries <see cref="EntrySO{T}"/> instead of Variables.
    /// </summary>
    /// <typeparam name="TEntry"></typeparam>
    /// <typeparam name="TData"></typeparam>
    /// <remarks>
    /// Reminder:
    /// Entries are meant to be used as a way to store references types which are not serialized in the Inspector.
    /// This way, each Entry stores a null by default and can be set to a value at runtime.
    /// When a non-null value is set, the Entry is considered defined.
    /// </remarks>
    public class NotifiedRegisterSO<TEntry, TData> : NotifiedArrayBaseSO<TData>,
        INotifiedRegister<TEntry, TData>,
        IDebuggable
        where TEntry : IEntry<TData>
    {
        [SerializeField]
        protected TEntry[] soRegister;

        private EventAttachmentManager<TEntry, TData> _attachementManager;

        public event Action<int> OnEmptyAt;
        public event Action OnEmptyAll;
        public event Action OnAnyChange;

        public TEntry[] Entries => soRegister;
        public override TData[] Value => GetAllValues();

        public int NumberOfDefinedEntries
        {
            get
            {
                int count = 0;

                foreach (TEntry entry in soRegister)
                {
                    if (entry.IsDefined)
                    {
                        count++;
                    }
                }

                return count;
            }
        }

        public bool IsFullyDefined
        {
            get
            {
                foreach (TEntry entry in soRegister)
                {
                    if (!entry.IsDefined)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        
        public override int Length => soRegister.Length;

        [InspectorButton]
        public void DebugAllEntries()
        {
            foreach (TEntry entry in soRegister)
            {
                entry.DebugState();
                Debug.Log("----------------------------------------");
            }
        }
        [InspectorButton]
        public void EmptyAll()
        {
            foreach (TEntry entry in soRegister)
            {
                entry.Empty();
            }
            OnEmptyAllHandler();
            OnAnyChangeHandler();
        }
        [InspectorButton]
        public void EmptyAt(int index)
        {
            if (index < 0 || index >= soRegister.Length)
            {
                Debug.LogWarning("Index out of bounds. Entry has not been emptied");
                return;
            }

            soRegister[index].Empty();
            OnEmptyAtHandler(index);
            OnAnyChangeHandler();
        }
        public void AddAt(TData entry, int index)
        {
            CollectionUtilities.CheckIndexRange(soRegister, index, nameof(AddAt));
            SetAt(index, entry);
        }
        public bool IsEmptyAt(int index)
        {
            if(CollectionUtilities.IsIndexOutOfBounds(soRegister, index))
            {
                Debug.LogWarning("Index out of bounds. Entry is not empty");
                return false;
            }

            return !soRegister[index].IsDefined;
        }
        public List<TEntry> GetAllEmptyEntries()
        {
            var emptyRegisters = new List<TEntry>();

            foreach (TEntry entry in soRegister)
            {
                if (!entry.IsDefined)
                {
                    emptyRegisters.Add(entry);
                }
            }

            return emptyRegisters;
        }
        public List<TEntry> GetAllDefinedEntries()
        {
            var nonEmptyRegisters = new List<TEntry>();

            foreach (TEntry entry in soRegister)
            {
                if (entry.IsDefined)
                {
                    nonEmptyRegisters.Add(entry);
                }
            }

            return nonEmptyRegisters;
        }
        public int[] GetIndexesOfDefinedEntries()
        {
            int[] result;

            if (NumberOfDefinedEntries == 0)
            {
                result = new int[0];
                return result; // return an array of length 0 with -1 as the only element
            }
            else
            {
                result = new int[NumberOfDefinedEntries];
                int index = 0;

                for (int i = 0; i < soRegister.Length; i++)
                {
                    if (soRegister[i].IsDefined)
                    {
                        result[index] = i;
                        index++;
                    }
                }

                return result;
            }
        }
        public int[] GetIndexesOfEmptyEntries()
        {
            int[] result;

            if (NumberOfDefinedEntries == soRegister.Length)
            {
                result = new int[0];
                return result; // return an array of length 0 
            }
            else
            {
                result = new int[soRegister.Length - NumberOfDefinedEntries];
                int index = 0;

                for (int i = 0; i < soRegister.Length; i++)
                {
                    if (!soRegister[i].IsDefined)
                    {
                        result[index] = i;
                        index++;
                    }
                }

                return result;
            }
        }
        public int GetIndexOfFirstEmptyEntry()
        {
            var index = -1;

            foreach (TEntry entry in soRegister)
            {
                index++;

                if (!entry.IsDefined)
                {
                    return index;
                }
            }

            return -1;
        }
        public int GetIndexOfFirstDefinedEntry()
        {
            var index = -1;

            foreach (TEntry entry in soRegister)
            {
                index++;

                if (entry.IsDefined)
                {
                    return index;
                }
            }

            return -1;
        }
        public int GetIndexOfNextDefinedEntry(int startIndex, bool loopMode = false)
        {
            if (startIndex < 0 || startIndex >= soRegister.Length)
            {
                if (loopMode)
                {
                    Debug.LogWarning("StartIndex out of bounds. Will loop from the beginning");
                    startIndex = -1;
                }
                else
                {
                    return -1;
                }
            }

            for (int i = startIndex+1; i < soRegister.Length; i++)
            {
                if (soRegister[i].IsDefined)
                {
                    return i;
                }
            }

            if (startIndex == 0)
            {
                return -1;
            }

            if (loopMode)
            {
                for (int i = 0; i < startIndex; i++)
                {
                    if (soRegister[i].IsDefined)
                    {
                        return i;
                    }
                }
                return -1;
            }
            else
            {
                return -1;
            }
        }
        public void SetEntriesID()
        {
           for (int i = 0; i < soRegister.Length; i++)
            {
                soRegister[i].ID = i;
            }
           OnAnyChange?.Invoke();
        }
        public TEntry GetVariableAt(int index)
        {
            CheckInitState();
            CollectionUtilities.CheckIndexRange(soRegister, index, nameof(GetVariableAt));
            return soRegister[index];
        }
        public override TData GetAt(int index)
        {
            CheckInitState();
            CollectionUtilities.CheckIndexRange(soRegister, index, nameof(GetAt));
            return soRegister[index].Value;
        }
        public override void SetAt(int index, TData value)
        {
            CheckInitState();
            CollectionUtilities.CheckIndexRange(soRegister, index, nameof(SetAt));
            var soVariable = soRegister[index];
            soVariable.SetValue(value);
            OnAnyChangeHandler();
        }
        public override void SetAll(TData[] values)
        {
            CheckInitState();

            if (values.Length != soRegister.Length)
            {
                Debug.LogWarning("Values array length does not match PointedArray length");
                return;
            }

            for (int i = 0; i < soRegister.Length; i++)
            {
                SetAt(i, values[i]);
            }
        }
        public override void SetAllToSame(TData value)
        {
            CheckInitState();

            foreach (var soVariable in soRegister)
            {
                soVariable.SetValue(value);
            }
            OnAnyChangeHandler();
        }
        public override void Subscribe()
        {
            if(soRegister.Length == 0)
            {
                Debug.LogWarning("ArraySO is empty. Skipping initialization");
                return;
            }

            _attachementManager ??= new EventAttachmentManager<TEntry, TData>(this, soRegister);
            _attachementManager.AttachHandlers(OnNewValueHandler);
            _isInitialized = true;
        }
        public override void Unsubscribe()
        {
            _attachementManager ??= new EventAttachmentManager<TEntry, TData>(this, soRegister);
            _attachementManager.DetachHandlers();
            _isInitialized = false;
        }
        public override void GetAll(TData[] destination)
        {
            CheckInitState();

            if (destination.Length != soRegister.Length)
                throw new System.ArgumentException("The length of the given array does not match the length of the SOArray");

            for (int i = 0; i < soRegister.Length; i++)
            {
                destination[i] = soRegister[i].Value;
            }

        }
        private TData[] GetAllValues()
        {
            TData[] result = new TData[soRegister.Length];

            // fill the array with the values of the pointed elements
            for (int i = 0; i < soRegister.Length; i++)
            {
                result.SetValue(soRegister[i].Value, i);
            }

            return result;
        }

        [InspectorButton]
        public void DebugState()
        {
            string debugInfo = $"Array-Length: {Length}, NumberOfNonEmptyEntries: {NumberOfDefinedEntries}, IsFullySet: {IsFullyDefined}";
            Debug.Log(debugInfo);

            if (_isInitialized)
            {
                Debug.Log(_attachementManager.GetAttachementInformations());
            }

            DebugAllEntries();
        }
        public void OnEmptyAtHandler(int index)
        {
            OnEmptyAt?.Invoke(index);
        }
        public void OnEmptyAllHandler()
        {
            OnEmptyAll?.Invoke();
        }
        public void OnAnyChangeHandler()
        {
            OnAnyChange?.Invoke();
        }
    }
}