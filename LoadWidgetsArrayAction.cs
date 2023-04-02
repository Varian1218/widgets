using System.Linq;
using UnityEngine;

namespace Widgets
{
    public class LoadWidgetsArrayAction : MonoBehaviour
    {
        [SerializeField] private UnityWidgets[] widgets;
        [SerializeField] private ScriptableObjectWidgetsArray widgetsArray;

        public void Invoke()
        {
            widgetsArray.Impl = new WidgetsArray
            {
                Widgets = widgets.Select(it => it as IWidgets).ToArray()
            };
            foreach (var it in widgets)
            {
                DontDestroyOnLoad(it);
            }
        }
    }
}