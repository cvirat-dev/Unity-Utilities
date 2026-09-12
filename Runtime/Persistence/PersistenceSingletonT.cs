using UnityEngine;
using UUP.CustomAttributes;
using UUP.CustomAttributes.CustomTargets;

namespace UUP.Persistence
{
    public class PersistentSingletonT<T> : MonoBehaviourT where T : Component
    {
        [Title("Persistent Singleton", "Can only exist once")]
        [Tooltip("if this is true, this singleton will auto detach if it finds itself parented on awake")]
        public bool UnparentOnAwake = true;

        public static bool HasInstance => instance != null;
        public static T Current => instance;

        protected static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindFirstObjectByType<T>();
                    if (instance == null)
                    {
                        Debug.LogWarning("No instance of " + typeof(T).Name + " found. Creating one.");
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name + "AutoCreated";
                        instance = obj.AddComponent<T>();
                    }
                }

                return instance;
            }
        }

        protected virtual void Awake() => InitializeSingleton();

        protected virtual void InitializeSingleton()
        {
            if (!Application.isPlaying)
            {
                return;
            }

            if (UnparentOnAwake)
            {
                transform.SetParent(null);
            }

            if (instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(transform.gameObject);
                enabled = true;
            }
            else
            {
                if (this != instance)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
