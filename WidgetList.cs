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

        public void Remove(int hashCode)
        {
            _widgets.Remove(hashCode);
        }
    }
}