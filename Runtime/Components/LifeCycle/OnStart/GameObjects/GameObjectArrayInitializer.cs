using UUP.Enums;
using UUP.Utilities.GameObjectUtils;
using UnityEngine;

namespace UUP.Components.LifeCycle.OnStart.GameObjects
{
    public class GameObjectArrayInitializer : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] GameObjects;

        [SerializeField,Header("GameObject-Active-State On Start")]
        private ActiveState option;

        // Start is called before the first frame update
        void Start()
        {
            if (ArrayUtils.ContainsNullElement(GameObjects))
            {
                Debug.LogError("There are empty elements in the array");
            }

            switch (option)
            {
                case ActiveState.Active:
                    ArrayUtils.ActivateAll(GameObjects);
                    break;
                case ActiveState.Inactive:
                    ArrayUtils.DeactivateAll(GameObjects);
                    break;
            }
        }
    }
}