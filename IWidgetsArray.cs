using System;

namespace Widgets
{
    public interface IWidgetsArray
    {
        IWidgets this[int index] { get; }
        IWidgets this[Index index] { get; }
    }
}