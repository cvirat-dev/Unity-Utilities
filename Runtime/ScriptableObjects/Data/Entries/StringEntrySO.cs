
using UnityEngine;

namespace UUP.ScriptableObjects.Data.Entries
{
    [CreateAssetMenu(
        menuName = "UUP/Data/Entries/StringEntry", 
        fileName = "StringEntry", order = 0)]
    public class StringEntrySO : EntrySO<string>
    {
        public override void DebugValueContent()
        {
            Debug.Log($"Value: {Value}");
        }
    }
}