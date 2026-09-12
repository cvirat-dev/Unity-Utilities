using UUP.ScriptableObjects.Data.Variables;
using UUP.ScriptableObjects.Data.Variables.Arrays;
using UnityEngine;

namespace UUP.ScriptableObjects.Operations.IndexedArraysHandlers
{
    [CreateAssetMenu(menuName = "UUP/Operations/Arrays/IndexedArraysEventHandlers/IntIndexedArrayEventHandler", fileName = "IntIndexedArrayEventHandler")]
    public class IntIndexedArrayEventHandlerSO : IndexedArrayEventHandlerSO<IntArraySO, IntVariableSO, int>
    {
    }
}