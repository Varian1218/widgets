namespace Widgets
{
    public interface IWidgetsArray
    {
        IWidgets this[int index] { get; }
    }
}