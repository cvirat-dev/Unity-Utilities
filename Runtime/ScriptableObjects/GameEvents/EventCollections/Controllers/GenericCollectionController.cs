using UUP.CustomAttributes;
using UUP.CustomAttributes.CustomTargets;

namespace UUP.ScriptableObjects.GameEvents.EventCollections.Controllers
{
    public class GenericCollectionController<T> : MonoBehaviourT where T : ICollectionEvents
    {
        public T TypeCollection;

        [InspectorButton]
        public void TriggerAll()
        {
            TypeCollection.RaiseAll();
        }
    }
}