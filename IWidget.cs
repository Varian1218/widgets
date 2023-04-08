using System;
using Transforms;

namespace Widgets
{
    public interface IWidget
    {
        event Action Hidden;
        int Index { set; }
        int InstanceId { get; }
        ITransform Parent { set; }
        event Action Showed;
        bool Visible { set; }
        void Destroy();
        T GetComponent<T>();
    }
}