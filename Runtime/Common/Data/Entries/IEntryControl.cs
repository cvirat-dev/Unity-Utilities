using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UUP.Common.Data.Entries
{
    public interface IEntryControl
    {
        /// <summary>
        /// Returns true if the value of this Entry is defined : not null. Else, returns false
        /// </summary>
        public bool IsDefined { get; }

        /// <summary>
        /// Get the ID of this "entry"
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Empty this Entry by setting the value to null
        /// </summary>
        public void Empty();

        /// <summary>
        /// Debug the state of the variable: name, value, isDefined, isSelected
        /// </summary>
        void DebugState();
    }
}
