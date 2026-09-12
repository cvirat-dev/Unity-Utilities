using System;

namespace UUP.Common.Data.Arrays
{ 
    public interface INotifiedArray<TData> : IArrayController<TData>, IArrayListener<TData>
    {
    }
}
