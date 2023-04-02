using System;

namespace Widgets
{
    public interface IWidget
    {
        event Action Hidden;
        int Index { set; }
        int InstanceId { get; }
        event Action Showed;
        bool Visible { set; }
        void Destroy();
        T GetComponent<T>();
    }
}