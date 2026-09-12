using UUP.ScriptableObjects.Data.Variables;
using UUP.ScriptableObjects.Data.Variables.Arrays;
using UnityEngine;

namespace UUP.ScriptableObjects.Operations.IndexedArraysHandlers
{
    [CreateAssetMenu(menuName = "UUP/Operations/Arrays/IndexedArraysEventHandlers/BoolIndexedArrayEventHandler", fileName = "BoolIndexedArrayEventHandler")]
    public class BoolIndexedArrayEventHandlerSO : IndexedArrayEventHandlerSO<BoolArraySO, BoolVariableSO, bool>
    {
    }
}