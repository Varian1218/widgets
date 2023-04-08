namespace Widgets
{
    public interface IWidgetFactory
    {
        T CreateWidget<T>(string widgetName) where T : class, ICustomWidget;
        void DestroyWidget(IWidget widget);
    }
}