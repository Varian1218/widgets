namespace Widgets
{
    public static class WidgetExtension
    {
        public static void Add(this IWidgets widgets, IWidget widget)
        {
            widgets.Add(widget, widget.InstanceId);
        }

        public static void Remove(this IWidgets widgets, IWidget widget)
        {
            widgets.Remove(widget.InstanceId);
        }
    }
}