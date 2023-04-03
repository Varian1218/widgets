namespace Widgets
{
    public static class WidgetExtension
    {
        public static void Add(this ICanvas canvas, IWidget widget)
        {
            canvas.Add(widget, widget.InstanceId);
        }

        public static void Remove(this ICanvas canvas, IWidget widget)
        {
            canvas.Remove(widget.InstanceId);
        }
    }
}