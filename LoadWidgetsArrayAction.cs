using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Widgets
{
    public class LoadWidgetsArrayAction : MonoBehaviour
    {
        [SerializeField] private UnityCanvas[] widgets;
        [FormerlySerializedAs("widgetsArray")] [SerializeField] private ScriptableObjectCanvasArray canvasArray;

        public void Invoke()
        {
            canvasArray.Impl = new CanvasArray
            {
                Widgets = widgets.Select(it => it as ICanvas).ToArray()
            };
            foreach (var it in widgets)
            {
                DontDestroyOnLoad(it);
            }
        }
    }
}