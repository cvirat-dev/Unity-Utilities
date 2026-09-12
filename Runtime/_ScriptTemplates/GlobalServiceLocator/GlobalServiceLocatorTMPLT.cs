using UnityEngine;

namespace UUP._ScriptTemplates.GlobalServiceLocator
{
    /// <summary>
    /// This template demonstrates how to create a global service locator.
    /// A global service locator is a singleton that holds references to all services in the game.
    /// It allows you to access services from any script in the game.
    /// Make a prefab of the GameObject that holds this script.
    /// Then reference this prefab in the ServiceLocatorStrapper and drag the ServiceLocatorStrapper into the scene.
    /// The ServiceLocatorStrapper will instantiate the prefab and make it a singleton.
    /// </summary>
    /// <remarks>
    /// Warning: This script is a template: Do not use this script in your project.
    /// Instead, create a "copy" of this script and use it in your project.
    /// <see cref="https://www.youtube.com/watch?v=tcatvGLvCDc&t=826s"/>
    /// </remarks>
    internal sealed class GlobalServiceLocatorTMPLT : MonoBehaviour
    {
        // Main-Singleton
        public static GlobalServiceLocatorTMPLT main { get; private set; }

        // All die unten auskommentierten Zeilen
        // zeigen Umgang mit Child-Components von GlobalServiceLocator

        //public InputKeyManager InputKeyManager { get; private set; }
        //public SceneTransitionManager SceneTransitionManager { get; private set; }
        //public GameInventory GameInventory { get; private set; }

        private void Awake()
        {
            if (main != null)
            {
                Destroy(this.gameObject);
                return;
            }

            main = this;
            DontDestroyOnLoad(this.gameObject);

            // Find all services in the game (Those must be children of the GlobalServiceLocator)
            //InputKeyManager = GetComponentInChildren<InputKeyManager>();
            //if (InputKeyManager != null) { print("InputKeyManager found!"); }

            //SceneTransitionManager = GetComponentInChildren<SceneTransitionManager>();
            //if (SceneTransitionManager != null) { print("SceneTransitionManager found!"); }

            //GameInventory = GetComponentInChildren<GameInventory>();
            //if (GameInventory != null) { print("GameInventory found!"); }
        }
    }

}

