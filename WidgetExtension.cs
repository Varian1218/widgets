namespace Widgets
{
    public static class WidgetExtension {
        public static void Add(this IWidgetList list, IWidget widget)
        {
            list.Add(widget, widget.InstanceId);
        }
    }
}