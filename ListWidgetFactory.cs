// namespace Widgets
// {
//     public class ListWidgetFactory : IWidgetFactory
//     {
//         private IWidgetFactory _impl;
//
//         public T CreateWidget<T>(string widgetName) where T : class, ICustomWidget
//         {
//             return _impl.CreateWidget<T>(widgetName);
//         }
//
//         public void DestroyWidget(IWidget widget)
//         {
//             _impl.DestroyWidget(widget);
//         }
//     }
// }