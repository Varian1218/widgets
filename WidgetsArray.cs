using System;

namespace Widgets
{
    public class WidgetsArray : IWidgetsArray
    {
        private IWidgets[] _widgets;

        public IWidgets[] Widgets
        {
            set => _widgets = value;
        }

        public IWidgets this[int index] => _widgets[index];
        public IWidgets this[Index index] => _widgets[index];
    }
}