using System;

namespace Widgets
{
    public interface IWidget
    {
        int ChildCount { get; }
        event Action Hidden;
        int Index { set; }
        IWidget Parent { set; }
        event Action Showed;
        bool Visible { set; }
        void Destroy();
        T GetComponent<T>();
    }
}