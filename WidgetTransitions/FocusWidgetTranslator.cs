using System.Collections.Generic;
using Tasks;

namespace Widgets.WidgetTransitions
{
    using Extensions = Queue<IWidgetExtension>;

    public class FocusWidgetTranslator : IWidgetTranslator
    {
        private Extensions _extensions;
        private IWidgetTranslator _impl;

        public Extensions Extensions
        {
            set => _extensions = value;
        }

        public IWidgetTranslator Impl
        {
            set => _impl = value;
        }

        public ITask TranslateAsync(bool negative, IWidgetExtension extension, float time)
        {
            _extensions.Focus(negative);
            if (!negative)
            {
                _extensions.Enqueue(extension);
            }

            WidgetTransitionUtility.Focus(extension, !negative);
            return _impl.TranslateAsync(negative, extension, time);
        }
    }
}