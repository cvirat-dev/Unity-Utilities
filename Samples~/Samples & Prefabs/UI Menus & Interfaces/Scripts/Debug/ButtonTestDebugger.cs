using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UUP.UI.Debugging
{
    public class ButtonTestDebugger : MonoBehaviour
    {
        public void PrintSomethingToConsole(Component sender, object data)
        {
            Debug.Log("Button pressed. " + "Component: " + sender + "; Object: " + data);
        }
    }
}