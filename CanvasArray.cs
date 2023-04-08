using System;

namespace Widgets
{
    public class CanvasArray : ICanvasArray
    {
        private ICanvas[] _impl;

        public ICanvas[] Impl
        {
            set => _impl = value;
        }

        public ICanvas this[int index] => _impl[index];
        public ICanvas this[Index index] => _impl[index];
    }
}