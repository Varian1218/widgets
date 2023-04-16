using System;
using Transforms;
using UnityEngine;

namespace Widgets
{
    public class MonoBehaviourWidget : MonoBehaviour, IWidget
    {
        public event Action Hidden;

        public int Index
        {
            set => transform.SetSiblingIndex(value);
        }

        public int InstanceId => gameObject.GetInstanceID();

        public ITransform Parent
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