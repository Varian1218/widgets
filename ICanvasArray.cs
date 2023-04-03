using System;

namespace Widgets
{
    public interface ICanvasArray
    {
        ICanvas this[int index] { get; }
        ICanvas this[Index index] { get; }
    }
}