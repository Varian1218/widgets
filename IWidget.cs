using System;
using Transforms;

namespace Widgets
{
    public interface IWidget : IComponentGetHandler
    {
        event Action Hidden;
        int Index { set; }
        int InstanceId { get; }
        event Action Showed;
        bool Visible { set; }
        void Destroy();
    }
}