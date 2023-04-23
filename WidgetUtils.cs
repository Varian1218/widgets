namespace Widgets
{
    public static class WidgetUtils
    {
        public static T CreateWidget<T>(this IWidgetFactory factory) where T : class
        {
            return factory.CreateWidget<T>(GetHash<T>());
        }
        
        public static T CreateWidget<T>(this IExtensionWidgetFactory factory) where T : class, IWidgetExtension
        {
            return factory.CreateWidget<T>(GetHash<T>());
        }

        public static string GetHash<T>()
        {
            return typeof(T).Name;
        }
    }
}