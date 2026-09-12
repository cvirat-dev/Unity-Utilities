using System;
using UnityEngine;

namespace UUP.Common.Events
{
    public interface ITimerEvent
    {
        public event Action OnTimerCompleted;
        public void StartTimer(MonoBehaviour monoBehaviour);
    }
}
