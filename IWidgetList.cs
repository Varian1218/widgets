using System.Collections.Generic;

namespace Widgets
{
    public interface IWidgetList : IEnumerable<IWidget>
    {
        void Add(IWidget widget, int widgetHashCode);
        void Clear();
        void Remove(int hashCode);
        IWidget this[int hashCode] { get; }
    }
}