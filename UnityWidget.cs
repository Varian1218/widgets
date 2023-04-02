using System;
using UnityEngine;

namespace Widgets
{
    public class UnityWidget : MonoBehaviour, IWidget
    {
        public event Action Hidden;

        public int Index
        {
            set => transform.SetSiblingIndex(value);
        }

        public int InstanceId => gameObject.GetInstanceID();

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