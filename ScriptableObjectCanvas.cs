using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Widgets
{
    [CreateAssetMenu(menuName = "Widgets/Canvas", fileName = "Canvas", order = 1)]
    public class ScriptableObjectCanvas : ScriptableObject, ICanvas
    {
        private ICanvas _impl;

        public ICanvas Impl
        {
            set => _impl = value;
        }

        public void Add(IWidget widget, int widgetHashCode)
        {
            _impl.Add(widget, widgetHashCode);
        }

        public void Clear()
        {
            _impl.Clear();
        }

        public IEnumerator<IWidget> GetEnumerator()
        {
            return _impl.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_impl).GetEnumerator();
        }

        public IWidget Remove(int hashCode)
        {
            return _impl.Remove(hashCode);
        }

        public void Remove(UnityWidget widget)
        {
            _impl.Remove(widget);
        }
    }
}