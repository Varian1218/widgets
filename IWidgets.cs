namespace Widgets
{
    public interface IWidgets
    {
        void Add(IWidget widget, int widgetHashCode);
        IWidget Remove(int hashCode);
        int RemoveAll(ref IWidget[] widgets);
    }
}