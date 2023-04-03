using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Widgets
{
    public class UnityWidgets : MonoBehaviour, IWidgets
    {
        private readonly Dictionary<int, IWidget> _widgets = new();

        public void Add(IWidget widget, int widgetHashCode)
        {
            _widgets.Add(widgetHashCode, widget);
            widget.GetComponent<Transform>().SetParent(transform, false);
        }

        public void Clear()
        {
            _widgets.Clear();
        }

        public IWidget Remove(int hashCode)
        {
            var widget = _widgets[hashCode];
            _widgets.Remove(hashCode);
            return widget;
        }

        public IEnumerator<IWidget> GetEnumerator()
        {
            return _widgets.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}