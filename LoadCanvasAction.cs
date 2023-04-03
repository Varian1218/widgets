using UnityEngine;

namespace Widgets
{
    public class LoadCanvasAction : MonoBehaviour
    {
        [SerializeField] private UnityCanvas canvas;
        [SerializeField] private ScriptableObjectCanvas sCanvas;

        public void Invoke()
        {
            sCanvas.Impl = canvas;
        }
    }
}