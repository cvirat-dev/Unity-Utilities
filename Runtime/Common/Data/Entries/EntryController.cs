using UUP.CustomAttributes;
using UUP.CustomAttributes.CustomTargets;
using UnityEngine;

namespace UUP.Common.Data.Entries
{
    public class EntryController<TEntry, TData> : MonoBehaviourT,
        IEntryControl
        where TEntry : IEntry<TData> where TData : class
    {
        [SerializeField] 
        TEntry Entry;

        public bool IsDefined => Entry.IsDefined;

        public int ID 
        { 
            get => Entry.ID; 
            set => Entry.ID = value; 
        }
        public TData Value 
        { 
            get => Entry.Value; 
            set => Entry.Value = value; 
        }

        [InspectorButton]
        public void DebugState()
        {
            Entry.DebugState();
        }

        [InspectorButton]
        public void Empty()
        {
            Entry.Empty();
        }

        [InspectorButton]
        public void SetValue(TData value)
        {
            Entry.SetValue(value);
        }

        [InspectorButton]
        public void SetID(int id)
        {
            Entry.ID = id;
        }
    }
}
