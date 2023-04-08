using UnityEngine;

namespace Widgets
{
    [CreateAssetMenu(fileName = "Load Widget List Action", menuName = "Widgets/Load Widget List Action", order = 1)]
    public class ScriptableObjectLoadWidgetListAction : ScriptableObject
    {
        [SerializeField] private ScriptableObjectWidgetList widgetList;

        public void Invoke()
        {
            widgetList.Impl = new WidgetList();
        }
    }
}