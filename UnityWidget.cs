// using System;
// using Transforms;
// using UnityEngine;
// using Object = UnityEngine.Object;
//
// namespace Widgets
// {
//     public class UnityWidget : IWidget
//     {
//         private GameObject _gameObject;
//         public event Action Hidden;
//
//         public int Index
//         {
//             set => _gameObject.transform.SetSiblingIndex(value);
//         }
//
//         public int InstanceId => _gameObject.GetInstanceID();
//
//         public GameObject GameObject
//         {
//             set => _gameObject = value;
//         }
//
//         public ITransform Parent
//         {
//             set => _gameObject.transform.SetParent(value.GetComponent<Transform>(), false);
//         }
//
//         public event Action Showed;
//
//         public bool Visible
//         {
//             set => _gameObject.SetActive(value);
//         }
//
//         public void Destroy()
//         {
//             Object.Destroy(_gameObject);
//         }
//
//         public T GetComponent<T>()
//         {
//             return _gameObject.GetComponent<T>();
//         }
//
//         private void OnDisable()
//         {
//             Hidden?.Invoke();
//         }
//
//         private void OnEnable()
//         {
//             Showed?.Invoke();
//         }
//     }
// }