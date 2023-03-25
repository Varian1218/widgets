using System;

namespace Widgets
{
    public interface IWidget
    {
        event Action<IWidget, bool> VisibleChanged;
        int ChildCount { get; }
        int Index { set; }
        IWidget Parent { set; }
        bool Visible { set; }
        T GetComponent<T>();
    }
}