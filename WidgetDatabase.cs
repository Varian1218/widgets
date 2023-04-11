using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Widgets
{
    [CreateAssetMenu(menuName = "Widgets/Widget Database", fileName = "Widget Database", order = 1)]
    public class WidgetDatabase : ScriptableObject, IEnumerable<(string, MonoBehaviour)>
    {
        [SerializeField] private MonoBehaviour[] widgets;
        public int Length => widgets?.Length ?? 0;

        public IEnumerable<MonoBehaviour> Values
        {
            get => widgets ?? Array.Empty<MonoBehaviour>();
            set => widgets = value.ToArray();
        }

        public IEnumerator<(string, MonoBehaviour)> GetEnumerator()
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
    }
}