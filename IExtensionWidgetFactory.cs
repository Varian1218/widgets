namespace Widgets
{
    public interface IExtensionWidgetFactory
    {
        T CreateWidget<T>(string widgetName) where T : class, IWidgetExtension;
        void DestroyWidget(IWidget widget);
    }
}