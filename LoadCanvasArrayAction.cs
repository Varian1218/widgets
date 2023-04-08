using UnityEngine;

namespace Widgets
{
    public class LoadCanvasArrayAction : MonoBehaviour
    {
        [SerializeField] private UnityCanvas backCanvas;
        [SerializeField] private UnityCanvas frontCanvas;
        [SerializeField] private UnityCanvas middleCanvas;
        [SerializeField] private ScriptableObjectCanvasArray canvasArray;

        public void Invoke()
        {
            canvasArray.Impl = new CanvasArray
            {
                Impl = new ICanvas[]
                {
                    backCanvas,
                    middleCanvas,
                    frontCanvas
                }
            };
            backCanvas.Order = CanvasHashCode.Back;
            frontCanvas.Order = CanvasHashCode.Front;
            middleCanvas.Order = CanvasHashCode.Middle;
            DontDestroyOnLoad(backCanvas);
            DontDestroyOnLoad(frontCanvas);
            DontDestroyOnLoad(middleCanvas);
        }
    }
}