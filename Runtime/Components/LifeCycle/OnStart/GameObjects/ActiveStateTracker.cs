using UUP.ScriptableObjects.Data.Variables;
using UnityEngine;

namespace UUP.Components.LifeCycle.OnStart.GameObjects
{
    /// <summary>
    /// Tracks the active state of a GameObject at <see cref="Start"/> and sets a BoolVariableSO to TRUE if active, FALSE if not.
    /// </summary>
    /// <remarks>
    /// CANNOT put this script on the GameObject you want to track, 
    /// as it will not be able to track its own active state because
    /// if it is inactive, it will not run the Update method.
    /// </remarks>
    public class ActiveStateTracker : MonoBehaviour
    {
        [SerializeField, Header("The GameObject to track")]
        GameObject _GameObject;
        
        [SerializeField, Header("Tracker Variable"), 
            Tooltip("If the GO is active on Game-Start, will be set to TRUE. Else, FALSE")]
        BoolVariableSO boolVariable;

        private void Start()
        {
            boolVariable.SetValue(_GameObject.activeSelf);
        }
    }
}