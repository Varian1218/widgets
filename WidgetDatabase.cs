using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Widgets
{
    [CreateAssetMenu(menuName = "Widgets/Widget Database", fileName = "Widget Database", order = 1)]
    public class WidgetDatabase : ScriptableObject, IEnumerable<(string, MonoBehaviour)>
    {
        [SerializeField] private MonoBehaviour[] widgets;

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