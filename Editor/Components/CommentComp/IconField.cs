using UUP.Components.CommentComp;
using UnityEngine.UIElements;

namespace UUP.Editor.Components.CommentComp
{
    /// <summary>
    /// A field that displays an icon based on the value of an enum.
    /// </summary>
    public class IconField : BindableElement, INotifyValueChanged<int>
    {
        int _value;

        public int value 
        { 
            get => _value;
            set
            {
                if (_value == value)
                    return;

                int previousValue = _value;
                _value = value;

                // Notify of the change
                using(var changeEvent = ChangeEvent<int>.GetPooled(previousValue, _value))
                {
                    changeEvent.target = this;
                    SendEvent(changeEvent);
                }
                RefreshIcon();

            }
        }

        public IconField()
        {
            style.width = 30;
            style.height = 30;
            style.flexShrink = 0;
            RefreshIcon();
        }

        private void RefreshIcon()
        {
            // Clear the current icon
            base.ClearClassList();
            style.display = DisplayStyle.Flex;

            switch ((Comment.IconType)_value)
            {
                case Comment.IconType.None:
                    style.display = DisplayStyle.None;
                    break;
                case Comment.IconType.Info:
                    AddToClassList(HelpBox.iconInfoUssClassName);
                    break;
                case Comment.IconType.Warning:
                    AddToClassList(HelpBox.iconwarningUssClassName);
                    break;
            }

        }

        // 	Sets the value and, even if different, doesn't notify registers callbacks with a ChangeEvent_1
        public void SetValueWithoutNotify(int newValue)
        {
            _value = newValue;
            RefreshIcon();
        }
    }
}
