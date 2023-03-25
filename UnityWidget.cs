using System;
using UnityEngine;

namespace Widgets
{
    public class UnityWidget : MonoBehaviour, IWidget
    {
        public event Action<IWidget, bool> VisibleChanged;
        public int ChildCount => transform.childCount;

        public int Index
        {
            set => transform.SetSiblingIndex(value);
        }

        public IWidget Parent
        {
            set => transform.SetParent(value.GetComponent<Transform>());
        }

        public bool Visible
        {
            set
            {
                gameObject.SetActive(value);
                VisibleChanged?.Invoke(this, value);
            }
        }
    }
}