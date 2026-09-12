using System.Collections.Generic;

namespace UUP.Common.Data.ObservableLists
{
    public interface IObservableListController<TData>
    {
        int Count { get; }
        List<TData> Value { get; }

        void Add(TData item);
        void ModifyItem(int index, TData item);
        void RemoveAt(int index);
        void MoveItem(int oldIndex, int newIndex);
        void Clear();
        TData GetAt(int index);
        bool Contains(TData item);
        int IndexOf(TData item);
        void Set(List<TData> items);
    }
}
