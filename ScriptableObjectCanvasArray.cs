using System;
using UnityEngine;

namespace Widgets
{
    [CreateAssetMenu(menuName = "Widgets/Widgets Array", fileName = "Widgets Array", order = 1)]
    public class ScriptableObjectCanvasArray : ScriptableObject, ICanvasArray
    {
        private ICanvasArray _impl;

        public ICanvasArray Impl
        {
            set => _impl = value;
        }

        public ICanvas this[int index] => _impl[index];
        public ICanvas this[Index index] => _impl[index];
    }
}