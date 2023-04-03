using System;

namespace Widgets
{
    public class CanvasArray : ICanvasArray
    {
        private ICanvas[] _widgets;

        public ICanvas[] Widgets
        {
            set => _widgets = value;
        }

        public ICanvas this[int index] => _widgets[index];
        public ICanvas this[Index index] => _widgets[index];
    }
}