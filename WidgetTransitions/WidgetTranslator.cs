using System;
using Tasks;

namespace Widgets.WidgetTransitions
{
    using AddStep = Action<Func<float, bool>>;

    public class WidgetTranslator : IWidgetTranslator
    {
        private AddStep _addStep;

        public AddStep AddStep
        {
            set => _addStep = value;
        }

        public async ITask TranslateAsync(bool negative, IWidgetExtension extension, float time)
        {
            extension.Transition.BeginStep(negative, time);
            await TaskUtils.Wait(extension.Transition.Step, _addStep);
        }
    }
}