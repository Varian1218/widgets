using System;
using Transforms;
using UnityEngine;
using Widgets.WidgetEvents;

namespace Widgets
{
    public class MonoBehaviourWidget : MonoBehaviour, IWidget
    {
        private class WidgetEvents : IWidgetEvents
        {
            public Action Hidden;
            public Action Showed;

            event Action IWidgetEvents.Hidden
            {
                add => Hidden += value;
                remove => Hidden -= value;
            }

            event Action IWidgetEvents.Showed
            {
                add => Showed += value;
                remove => Showed -= value;
            }
        }

        private readonly WidgetEvents _events = new();

        public IWidgetEvents Events => _events;

        public int Index
        {
            set => transform.SetSiblingIndex(value);
        }

        public int InstanceId => gameObject.GetInstanceID();

        public ITransform Parent
        {
            set => transform.SetParent(value.GetComponent<Transform>(), false);
        }

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
            _events.Hidden?.Invoke();
        }

        private void OnEnable()
        {
            _events.Showed?.Invoke();
        }
    }
}