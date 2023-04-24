using Transitions;

namespace Widgets.WidgetTransitions
{
    public interface IWidgetExtension : Widgets.IWidgetExtension
    {
        ITransition Transition { get; }
    }
}