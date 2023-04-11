#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Widgets.Editors
{
    [CustomEditor(typeof(UnityWidget))]
    public class UnityWidgetEditor : Editor
    {
        private WidgetDatabase[] _widgetDatabases;

        private void OnEnable()
        {
            _widgetDatabases = AssetDatabase.FindAssets($"t:{typeof(WidgetDatabase)}")
                .Select(it => AssetDatabase.LoadAssetAtPath<WidgetDatabase>(AssetDatabase.GUIDToAssetPath(it)))
                .ToArray();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (_widgetDatabases == null || _widgetDatabases.Length == 0)
            {
                EditorGUILayout.HelpBox("You must be create widget list", MessageType.Warning);
            }
            else
            {
                var widget = target as UnityWidget ?? throw new NullReferenceException();
                foreach (var database in _widgetDatabases)
                {
                    var instanceId = widget.gameObject.GetInstanceID();
                    var map = database.Values.ToDictionary(it => it.gameObject.GetInstanceID());
                    map.TryGetValue(instanceId, out var monoWidget);
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(database.name);
                    var objectWidget = EditorGUILayout.ObjectField(
                        monoWidget,
                        typeof(MonoBehaviour),
                        false
                    ) as MonoBehaviour;
                    EditorGUILayout.EndHorizontal();
                    if (objectWidget)
                    {
                        if (!monoWidget)
                        {
                            map.Add(instanceId, objectWidget);
                        }

                        var binding = BindingFlags.Instance | BindingFlags.NonPublic;
                        var widgetField = objectWidget.GetType().GetField("widget", binding);
                        if (widgetField == null)
                        {
                            EditorGUILayout.HelpBox("Missing widget field", MessageType.Warning);
                        }
                        else
                        {
                            if (widgetField.GetValue(objectWidget) as UnityWidget != widget)
                            {
                                widgetField.SetValue(objectWidget, widget);
                                EditorUtility.SetDirty(objectWidget);
                                AssetDatabase.SaveAssetIfDirty(objectWidget);
                            }
                        }
                    }
                    else
                    {
                        if (monoWidget)
                        {
                            map.Remove(instanceId);
                        }
                    }

                    if (objectWidget == monoWidget) continue;
                    database.Values = map.Values.OrderBy(it => it.name);
                    EditorUtility.SetDirty(database);
                    AssetDatabase.SaveAssetIfDirty(database);
                }
            }
        }
    }
}
#endif