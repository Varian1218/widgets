namespace Widgets
{
    public interface IWidgetFactory
    {
        T CreateWidget<T>(string widgetName) where T : class;
        void DestroyWidget(IWidget widget);
    }
}