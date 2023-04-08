using System;
using System.Collections;
using System.Collections.Generic;

namespace Widgets
{
    public class EventWidgetList : IWidgetList
    {
        private IWidgetList _impl;
        private Action<IWidget> _preAdd;
        private Action<IWidget> _preRemove;

        public IWidgetList Impl
        {
            set => _impl = value;
        }

        public Action<IWidget> PreAdd
        {
            set => _preAdd = value;
        }

        public Action<IWidget> PreRemove
        {
            set => _preRemove = value;
        }

        public void Add(IWidget widget, int widgetHashCode)
        {
            _preRemove(widget);
            _impl.Add(widget, widgetHashCode);
        }

        public IEnumerator<IWidget> GetEnumerator()
        {
            return _impl.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_impl).GetEnumerator();
        }

        public void Remove(int hashCode)
        {
            _preRemove(_impl[hashCode]);
            _impl.Remove(hashCode);
        }

        public IWidget this[int hashCode] => _impl[hashCode];
    }
}