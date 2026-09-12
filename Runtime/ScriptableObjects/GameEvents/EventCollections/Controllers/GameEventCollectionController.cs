using UUP.CustomAttributes;
using UUP.CustomAttributes.CustomTargets;
using UnityEngine;

namespace UUP.ScriptableObjects.GameEvents.EventCollections
{
    /// <summary>
    /// This controller allows to trigger all GameEvents in the collection at once.
    /// Important note: Those GameEvents are empty signals, they do not carry any data.
    /// </summary>
    public class GECollectionController : MonoBehaviourT
    {
        [SerializeField] 
        private GameEventCollection collection;

        [InspectorButton]
        public void OnTriggerAll()
        {
            collection.RaiseAll();
        }
    }
}