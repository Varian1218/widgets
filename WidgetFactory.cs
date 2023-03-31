using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Widgets
{
    public class WidgetFactory : IWidgetFactory
    {
        private readonly Dictionary<string, Object> _widgets = new();

        public void AddWidget<TInterface, TClass>(TClass widget) where TClass : MonoBehaviour, TInterface
        {
            AddWidget(WidgetUtils.GetHash<TInterface>(), widget);
        }

        public void AddWidget(string widgetName, Object widget)
        {
            _widgets.Add(widgetName, widget);
        }

        public T CreateWidget<T>(string widgetName) where T : class
        {
            var widget = _widgets[widgetName];
            return Object.Instantiate(widget) as T ?? throw new NullReferenceException(widget.GetType().Name);
        }

        public void DestroyWidget(IWidget widget)
        {
            Object.Destroy(widget.GetComponent<MonoBehaviour>().gameObject);
        }
    }
}