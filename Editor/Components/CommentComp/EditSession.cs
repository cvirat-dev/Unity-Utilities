using UnityEditor;
using UnityEngine;

namespace UUP.Editor.Components.CommentComp
{
    /// <summary>
    /// Stores the editing state for a provided target.
    /// </summary>
    /// <remarks>
    /// To store values across domain reload, the target must be persistent.
    /// This means, two session instances pointing to the same target instance
    /// will both return the same <see cref="IsEditing"/> value.
    /// </remarks>
    internal sealed class EditSession
    {
        private readonly string _key; // Unique key for the target instance
        private readonly bool _defaultValue;

        private const string PREFIX = "UUP.Editor.InspectorUtils.CommentComp.EditSession_";

        public EditSession(Object target, bool defaultValue = false)
        {
            if (target == null)
            {
                throw new System.ArgumentNullException(nameof(target));
            }

            _key = PREFIX + target.GetInstanceID().ToString();
            this._defaultValue = defaultValue;
        }

        public void Clear()
        {
            SessionState.EraseBool(_key);
        }

        public bool IsEditing
        {
            get => SessionState.GetBool(_key, _defaultValue);
            set => SessionState.SetBool(_key, value);
        }
    }
}
