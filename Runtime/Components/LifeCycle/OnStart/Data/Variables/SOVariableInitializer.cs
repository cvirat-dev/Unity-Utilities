using UUP.ScriptableObjects.Data.Variables;
using UnityEngine;

namespace UUP.Components.LifeCycle.Data.Variables
{
    /// <summary>
    /// Base class for initializing a variable on start.
    /// Because of the nature of Scripsble Objects which are not reset after play mode, this is a way to reset the value of a variable on start.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public abstract class SOVariableInitializer<T1, T2> : MonoBehaviour where T1 : VariableSO<T2>
    {
        [SerializeField] private T1 variable;
        [SerializeField] private T2 StartValue;

        // Start is called before the first frame update
        void Start()
        {
            if (variable != null)
            {
                variable.SetValue(StartValue);
            }
            else
            {
                Debug.LogError("Reference to variable is null");
            }
        }
    }
}