using UUP.ScriptableObjects.Data.Variables;
using UUP.ScriptableObjects.Data.Variables.Arrays;
using UnityEngine;

namespace UUP.ScriptableObjects.Operations.IndexedArraysHandlers
{
    [CreateAssetMenu(menuName = "UUP/Operations/Arrays/IndexedArraysEventHandlers/FloatIndexedArrayEventHandler", fileName = "FloatIndexedArrayEventHandler")]
    public class FloatIndexedArrayEventHandlerSO : IndexedArrayEventHandlerSO<FloatArraySO, FloatVariableSO, float>
    {
    }
}