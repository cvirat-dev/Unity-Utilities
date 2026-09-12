using UnityEngine;

namespace UUP.CustomAttributes
{
    public interface IButtonAttribute
    {
        string Error { get; }
        bool PerformValidation(Object obj);
    }
}
