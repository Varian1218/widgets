using UnityEngine;

namespace Widgets
{
    [CreateAssetMenu(menuName = "Widgets/Load Widget Factory", fileName = "Load Widget Factory", order = 1)]
    public class ScriptableObjectLoadWidgetFactory : ScriptableObject
    {
        [SerializeField] private WidgetDatabase widgetDatabase;
        [SerializeField] private ScriptableObjectWidgetFactory widgetFactory;

        public void Invoke()
        {
            var wf = new WidgetFactory();
            widgetFactory.Impl = wf;
            foreach (var (hash, widget) in widgetDatabase)
            {
                wf.AddWidget(hash, widget);
            }
        }
    }
}