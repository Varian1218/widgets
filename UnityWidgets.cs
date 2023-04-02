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

        public IWidget Remove(int hashCode)
        {
            var widget = _widgets[hashCode];
            _widgets.Remove(hashCode);
            return widget;
        }

        public int RemoveAll(ref IWidget[] widgets)
        {
            var i = 0;
            foreach (var widget in _widgets.Values)
            {
                widgets[i] = widget;
                i++;
            }
            _widgets.Clear();
            return i;
        }
    }
}