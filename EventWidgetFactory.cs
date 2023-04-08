// using System;
//
// namespace Widgets
// {
//     public class EventWidgetFactory : IWidgetFactory
//     {
//         private IWidgetFactory _impl;
//         private Action<IWidget> _postCreate;
//         public T CreateWidget<T>(string widgetName) where T : class
//         {
//             var widget = _impl.CreateWidget<T>(widgetName);
//             _postCreate(widget);
//             return widget;
//         }
//
//         public void DestroyWidget(IWidget widget)
//         {
//             _impl.DestroyWidget(widget);
//         }
//     }
// }