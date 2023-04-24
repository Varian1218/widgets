using System.Collections.Generic;

namespace Widgets.WidgetTransitions
{
    public static class WidgetTransitionUtility
    {
        public static void Focus(this Queue<IWidgetExtension> extensions, bool focus)
        {
            if (extensions.TryPeek(out var value))
            {
                Focus(value, focus);
            }
        }

        public static void Focus(object extension, bool focus)
        {
            if (extension is IWidgetFocusHandler focusHandler)
            {
                focusHandler.OnWidgetFocus(focus);
            }
        }
    }
}