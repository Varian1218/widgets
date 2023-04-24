using System;
using Tasks;

namespace Widgets.WidgetTransitions
{
    using DestroyWidget = Action<IWidgetExtension>;

    public class DestroyWidgetWidgetTranslator : IWidgetTranslator
    {
        private DestroyWidget _destroyWidget;
        private IWidgetTranslator _impl;

        public DestroyWidget DestroyWidget
        {
            set => _destroyWidget = value;
        }

        public IWidgetTranslator Impl
        {
            set => _impl = value;
        }

        public async ITask TranslateAsync(bool negative, IWidgetExtension extension, float time)
        {
            await _impl.TranslateAsync(negative, extension, time);
            if (negative)
            {
                _destroyWidget(extension);
            }
        }
    }
}