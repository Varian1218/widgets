#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
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
                    );
                    EditorGUILayout.EndHorizontal();
                    if (objectWidget)
                    {
                        if (!monoWidget)
                        {
                            map.Add(instanceId, widget);
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