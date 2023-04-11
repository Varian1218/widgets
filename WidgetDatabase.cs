using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Widgets
{
    [CreateAssetMenu(menuName = "Widgets/Widget Database", fileName = "Widget Database", order = 1)]
    public class WidgetDatabase : ScriptableObject, IEnumerable<(string, UnityWidget)>
    {
        [SerializeField] private UnityWidget[] widgets;
        public int Length => widgets?.Length ?? 0;

        public IEnumerable<UnityWidget> Values
        {
            get => widgets ?? Array.Empty<UnityWidget>();
            set => widgets = value.ToArray();
        }

        public IEnumerator<(string, UnityWidget)> GetEnumerator()
        {
            return widgets.Select(it => (GetHash(it), it)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private static string GetHash(Object behaviour)
        {
            return $"I{behaviour.name}";
        }

        public HashSet<UnityWidget> ToHashSet()
        {
            return widgets == null ? new HashSet<UnityWidget>() : widgets.ToHashSet();
        }
    }
}