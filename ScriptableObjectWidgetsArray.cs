using System;
using UnityEngine;

namespace Widgets
{
    [CreateAssetMenu(menuName = "Widgets/Widgets Array", fileName = "Widgets Array", order = 1)]
    public class ScriptableObjectWidgetsArray : ScriptableObject, IWidgetsArray
    {
        [SerializeField] private UnityWidgets[] widgets;

        public IWidgets this[int index] => widgets[index];
        public IWidgets this[Index index] => widgets[index];
    }
}