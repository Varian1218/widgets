using System;
using UnityEngine;

namespace Widgets
{
    [CreateAssetMenu(menuName = "Widgets/Widgets Array", fileName = "Widgets Array", order = 1)]
    public class ScriptableObjectWidgetsArray : ScriptableObject, IWidgetsArray
    {
        private IWidgetsArray _impl;

        public IWidgetsArray Impl
        {
            set => _impl = value;
        }

        public IWidgets this[int index] => _impl[index];
        public IWidgets this[Index index] => _impl[index];
    }
}