using System;
using Transforms;
using Widgets.WidgetEvents;

namespace Widgets
{
    public interface IWidget : IComponentGetHandler
    {
        IWidgetEvents Events { get; }
        int Index { set; }
        int InstanceId { get; }
        bool Visible { set; }
        void Destroy();
    }
}