#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Kamatte.Core
{
    [CustomEditor(typeof(UIFactory))]
    public class UIFactoryEditor : Editor    //  UIFactory(SO)のインスペクターを拡張する
    {
        private ReorderableList list;

        private void OnEnable()    //  SOのインスペクターの見た目をいじる
        {
            var mappingsProp = serializedObject.FindProperty("uiMappings");

            list = new ReorderableList(serializedObject, mappingsProp, true, true, true, true);
            list.drawElementCallback = (rect, index, isActive, isFocused) =>
            {
                var element = mappingsProp.GetArrayElementAtIndex(index);
                EditorGUI.PropertyField(
                    new Rect(rect.x, rect.y, rect.width / 2, EditorGUIUtility.singleLineHeight),
                    element.FindPropertyRelative("uiID"), GUIContent.none);

                EditorGUI.PropertyField(
                    new Rect(rect.x + rect.width / 2, rect.y, rect.width / 2, EditorGUIUtility.singleLineHeight),
                    element.FindPropertyRelative("uiPrefab"), GUIContent.none);
            };

            list.drawHeaderCallback = (rect) =>
            {
                EditorGUI.LabelField(rect, "UI Mappings (UIID → Prefab)");
            };
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("sceneIDConvert"));
            list.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif