using System;

namespace UUP.Common.Data.Arrays
{
    public interface IArrayChangeNotification<TData>
    {
        public event Action<int, TData> OnNewValue;
        public void OnNewValueHandler(int index, TData data);
    }
}
