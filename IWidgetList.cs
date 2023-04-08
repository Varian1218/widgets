namespace Widgets
{
    public interface IWidgetList
    {
        void Add(IWidget widget, int widgetHashCode);
        void Remove(int hashCode);
    }
}