using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Widgets
{
    [CreateAssetMenu(menuName = "Widgets/Widget List", fileName = "Widget List", order = 1)]
    public class ScriptableObjectWidgetList : ScriptableObject, IWidgetList
    {
        private IWidgetList _impl;

        public IWidgetList Impl
        {
            set => _impl = value;
        }

        public void Add(IWidget widget, int widgetHashCode)
        {
            _impl.Add(widget, widgetHashCode);
        }

        public void Remove(UnityWidget widget)
        {
            Remove(widget.InstanceId);
        }

        public void Remove(int hashCode)
        {
            _impl.Remove(hashCode);
        }

        public IWidget this[int hashCode] => _impl[hashCode];

        public IEnumerator<IWidget> GetEnumerator()
        {
            return _impl.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_impl).GetEnumerator();
        }
    }
}