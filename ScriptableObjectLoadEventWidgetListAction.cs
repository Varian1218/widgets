using Transforms;
using UnityEngine;

namespace Widgets
{
    [CreateAssetMenu(
        fileName = "Load Event Widget List Action",
        menuName = "Widgets/Load Event Widget List Action",
        order = 1
    )]
    public class ScriptableObjectLoadEventWidgetListAction : ScriptableObject
    {
        [SerializeField] private ScriptableObjectTransform transform;
        [SerializeField] private ScriptableObjectWidgetFactory widgetFactory;
        [SerializeField] private ScriptableObjectWidgetList widgetList;

        public void Invoke()
        {
            widgetList.Impl = new EventWidgetList
            {
                Impl = new WidgetList(),
                PreAdd = widget => widget.Parent = transform,
                PreClear = widgetFactory.DestroyWidgets,
                PreRemove = widgetFactory.DestroyWidget
            };
        }
    }
}