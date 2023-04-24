using Tasks;
using Widgets.WidgetEvents;

namespace Widgets.TaskWidgets
{
    public class TaskWidget
    {
        private readonly Awaiter _hiddenAwaiter = new();
        private readonly Awaiter _showedAwaiter = new();
        private ITask Hidden { get; }
        private ITask Showed { get; }

        public TaskWidget()
        {
            Hidden = new AwaiterTask(_hiddenAwaiter);
            Showed = new AwaiterTask(_showedAwaiter);
        }

        public IWidgetEvents Widget
        {
            set
            {
                value.Hidden += _hiddenAwaiter.Complete;
                value.Showed += _showedAwaiter.Complete;
            }
        }

        public void Clear()
        {
            _hiddenAwaiter.Clear();
            _showedAwaiter.Clear();
        }
    }
}