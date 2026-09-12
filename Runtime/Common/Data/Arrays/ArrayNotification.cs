using System.Collections.Generic;

namespace UUP.Common.Data.Arrays
{
    /// <summary>
    /// This class is used to store the content of the array that has been changed.
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class ArrayNotification<TData>
    {
        private readonly Dictionary<int, TData> _notifContent;
        public Dictionary<int, TData> NotificationContent => _notifContent;

        public ArrayNotification()
        {
            _notifContent = new Dictionary<int, TData>();
        }

        public ArrayNotification(TData[] prevData, TData[] newData)
        {
            _notifContent = new Dictionary<int, TData>();

            if (prevData.Length != newData.Length)
            {
                throw new System.ArgumentException("The length of the previous data and the new data must be the same.");
            }

            for (int i = 0; i < prevData.Length; i++)
            {
                if (!prevData[i].Equals(newData[i]))
                {
                    _notifContent.Add(i, newData[i]);
                }
            }
        }

        public void Add(int index, TData data)
        {
            _notifContent.Add(index, data);
        }

        public void Clear()
        {
            _notifContent.Clear();
        }
    }
}
