using System;

namespace Widgets.WidgetEvents
{
    public interface IWidgetEvents
    {
        event Action Hidden;
        event Action Showed;
    }
}