using System.Collections.Generic;

namespace Widgets
{
    public static class WidgetExtension
    {
        public static void Add(this IWidgetList list, IWidget widget)
        {
            list.Add(widget, widget.InstanceId);
        }

        public static void DestroyWidgets(this IWidgetFactory factory, IEnumerable<IWidget> widgets)
        {
            foreach (var widget in widgets)
            {
                factory.DestroyWidget(widget);
            }
        }
        
        public static void Remove(this IWidgetList list, IWidget widget)
        {
            list.Remove(widget.InstanceId);
        }
    }
}