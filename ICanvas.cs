using System.Collections.Generic;

namespace Widgets
{
    public interface ICanvas : IEnumerable<IWidget>
    {
        void Add(IWidget widget, int widgetHashCode);
        void Clear();
        IWidget Remove(int hashCode);
    }
}