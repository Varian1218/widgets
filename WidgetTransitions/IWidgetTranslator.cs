using Tasks;

namespace Widgets.WidgetTransitions
{
    public interface IWidgetTranslator
    {
        ITask TranslateAsync(bool negative, IWidgetExtension extension, float time);
    }
}