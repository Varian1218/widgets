#if UNITY_EDITOR
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
                var widget = target as UnityWidget;
                foreach (var database in _widgetDatabases)
                {
                    var hashSet = database.Values == null ? new HashSet<MonoBehaviour>() : database.Values.ToHashSet();
                    var value = hashSet.Contains(widget);
                    var toggle = EditorGUILayout.Toggle(database.name, value);
                    if (toggle)
                    {
                        if (!value)
                        {
                            hashSet.Add(widget);
                        }
                    }
                    else
                    {
                        if (value)
                        {
                            hashSet.Remove(widget);
                        }
                    }

                    if (toggle == value) continue;
                    database.Values = hashSet.OrderBy(it => it.name);
                    EditorUtility.SetDirty(database);
                    AssetDatabase.SaveAssetIfDirty(database);
                }
            }
        }
    }
}
#endif