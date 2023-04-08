using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Widgets
{
    public class UnityCanvas : MonoBehaviour, ICanvas
    {
        [SerializeField] private Canvas canvas;
        private readonly Dictionary<int, IWidget> _widgets = new();

        public int Order
        {
            set => canvas.sortingOrder = value;
        }

        public void Add(IWidget widget, int widgetHashCode)
        {
            widget.GetComponent<Transform>().SetParent(transform, false);
            _widgets.Add(widgetHashCode, widget);
        }

        public void Clear()
        {
            _widgets.Clear();
        }

        public IWidget Remove(int hashCode)
        {
            var widget = _widgets[hashCode];
            widget.GetComponent<Transform>().SetParent(null);
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