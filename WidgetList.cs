using System.Collections;
using System.Collections.Generic;

namespace Widgets
{
    public class WidgetList : IWidgetList
    {
        private readonly Dictionary<int, IWidget> _widgets = new();

        public void Add(IWidget widget, int widgetHashCode)
        {
            _widgets.Add(widgetHashCode, widget);
        }

        public void Clear()
        {
            _widgets.Clear();
        }

        public IEnumerator<IWidget> GetEnumerator()
        {
            return _widgets.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Remove(int hashCode)
        {
            _widgets.Remove(hashCode);
        }

        public IWidget this[int hashCode] => _widgets[hashCode];
    }
}