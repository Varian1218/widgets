using System;
using UnityEngine;

namespace Widgets
{
    public class UnityWidget : MonoBehaviour, IWidget
    {
        public int ChildCount => transform.childCount;
        public event Action Hidden;

        public int Index
        {
            set => transform.SetSiblingIndex(value);
        }

        public IWidget Parent
        {
            set => transform.SetParent(value.GetComponent<Transform>(), false);
        }

        public event Action Showed;

        public bool Visible
        {
            set => gameObject.SetActive(value);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        private void OnDisable()
        {
            Hidden?.Invoke();
        }

        private void OnEnable()
        {
            Showed?.Invoke();
        }
    }
}