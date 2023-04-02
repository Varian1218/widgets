namespace Widgets
{
    public static class WidgetExtension
    {
        public static void Add(this IWidgets widgets, IWidget widget)
        {
            widgets.Add(widget, widget.InstanceId);
        }
    }
}