using UnityEngine;

namespace Widgets
{
    [CreateAssetMenu(menuName = "Widgets/Widget Factory", fileName = "Widget Factory", order = 1)]
    public class ScriptableObjectWidgetFactory : ScriptableObject, IWidgetFactory
    {
        private IWidgetFactory _impl;

        public IWidgetFactory Impl
        {
            set => _impl = value;
        }

        public T CreateWidget<T>(string widgetName) where T : class
        {
            return _impl.CreateWidget<T>(widgetName);
        }

        public void DestroyWidget(IWidget widget)
        {
            _impl.DestroyWidget(widget);
        }
    }
}