using UUP.Common.Data.Arrays;
using UUP.CustomAttributes;
using System.Collections.Generic;
using UnityEngine;

namespace UUP.Common.Data.Entries.NotifiedRegisters
{
    public class NotifiedRegisterController<TNotifRegister, TEntry, TData> : NotifiedArrayControllerBase<TData>,
        INotifiedRegisterController<TEntry, TData>
        where TNotifRegister : INotifiedRegister<TEntry, TData>
        where TEntry : IEntry<TData>
    {
        [SerializeField] protected TNotifRegister registerSO;

        public override int Length => registerSO.Length;
        public override TData[] Value => registerSO.Value;
        public int NumberOfDefinedEntries => registerSO.NumberOfDefinedEntries;
        public bool IsFullyDefined => registerSO.IsFullyDefined;

        public void AddAt(TData entry, int index)
        {
            registerSO.AddAt(entry, index);
        }

        [InspectorButton]
        public void EmptyAll()
        {
            registerSO.EmptyAll();
        }

        [InspectorButton]
        public void EmptyAt(int index)
        {
            registerSO.EmptyAt(index);
        }

        public override void GetAll(TData[] destination)
        {
            registerSO.GetAll(destination);
        }

        public List<TEntry> GetAllDefinedEntries()
        {
            return registerSO.GetAllDefinedEntries();
        }

        public List<TEntry> GetAllEmptyEntries()
        {
            return registerSO.GetAllEmptyEntries();
        }

        public override TData GetAt(int index)
        {
            return registerSO.GetAt(index);
        }

        public int[] GetIndexesOfEmptyEntries()
        {
            return registerSO.GetIndexesOfEmptyEntries();
        }

        public int GetIndexOfFirstDefinedEntry()
        {
            return registerSO.GetIndexOfFirstDefinedEntry();
        }

        public int GetIndexOfFirstEmptyEntry()
        {
            return registerSO.GetIndexOfFirstEmptyEntry();
        }

        public int GetIndexOfNextDefinedEntry(int startIndex, bool loopMode)
        {
            return registerSO.GetIndexOfNextDefinedEntry(startIndex, loopMode);
        }

        public int[] GetIndexesOfDefinedEntries()
        {
            return registerSO.GetIndexesOfDefinedEntries();
        }

        public bool IsEmptyAt(int index)
        {
            return registerSO.IsEmptyAt(index);
        }

        public override void SetAll(TData[] values)
        {
            registerSO.SetAll(values);
        }

        public override void SetAllToSame(TData value)
        {
            registerSO.SetAllToSame(value);
        }

        public override void SetAt(int index, TData value)
        {
            registerSO.SetAt(index, value);
        }

        [InspectorButton]
        public void DebugAllEntries()
        {
            registerSO.DebugAllEntries();
        }
    }
}
