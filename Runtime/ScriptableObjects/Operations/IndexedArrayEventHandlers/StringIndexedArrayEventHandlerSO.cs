using UUP.ScriptableObjects.Data.Variables;
using UUP.ScriptableObjects.Data.Variables.Arrays;
using UnityEngine;

namespace UUP.ScriptableObjects.Operations.IndexedArraysHandlers
{
    [CreateAssetMenu(menuName = "UUP/Operations/Arrays/IndexedArraysEventHandlers/StringIndexedArrayEventHandler", fileName = "StringIndexedArrayEventHandler")]
    public class StringIndexedArrayEventHandlerSO : IndexedArrayEventHandlerSO<StringArraySO, StringVariableSO, string>
    {
    }
}