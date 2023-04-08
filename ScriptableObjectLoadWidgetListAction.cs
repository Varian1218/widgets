using UnityEngine;

namespace Widgets
{
    [CreateAssetMenu(menuName = "Widgets/Load Widget List Action", fileName = "Load Widget List Action", order = 1)]
    public class ScriptableObjectLoadWidgetListAction : ScriptableObject
    {
        [SerializeField] private ScriptableObjectWidgetList widgetList;

        public void Invoke()
        {
            widgetList.Impl = new WidgetList();
        }
    }
}