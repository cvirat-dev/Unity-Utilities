
using UUP.CustomAttributes;
using UUP.CustomAttributes.CustomTargets;

namespace UUP.ScriptableObjects.GameEvents.EventCollections
{
    public abstract class CollectionBase : ScriptableObjectT, ICollectionEvents
    {
        [InspectorButton]
        public abstract void RaiseAll();
    }
}
