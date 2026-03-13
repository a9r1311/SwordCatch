//#if UNITY_EDITOR
//using UnityEditor;
//using UnityEngine;
//using Kamatte.UI.Factory;

//[CustomPropertyDrawer(typeof(UIFactory.UIMap))]
//public class UIMapDrawer : PropertyDrawer
//{
//    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//    {
//        EditorGUI.BeginProperty(position, label, property);

//        float singleLineHeight = EditorGUIUtility.singleLineHeight;
//        var controllerIDProp = property.FindPropertyRelative("buttonControllerID");
//        var prefabProp = property.FindPropertyRelative("uiPrefab");

//        Rect controllerRect = new Rect(position.x, position.y, position.width, singleLineHeight);
//        Rect prefabRect = new Rect(position.x, position.y + singleLineHeight + 2, position.width, singleLineHeight);

//        EditorGUI.PropertyField(controllerRect, controllerIDProp);
//        EditorGUI.PropertyField(prefabRect, prefabProp);

//        // --- 自動代入ロジック ---
//        if (prefabProp.objectReferenceValue == null)
//        {
//            string expectedName = controllerIDProp.enumDisplayNames[controllerIDProp.enumValueIndex];

//            string[] guids = AssetDatabase.FindAssets($"t:GameObject {expectedName}");
//            foreach (string guid in guids)
//            {
//                string path = AssetDatabase.GUIDToAssetPath(guid);
//                GameObject go = AssetDatabase.LoadAssetAtPath<GameObject>(path);
//                if (go != null && go.name == expectedName)
//                {
//                    prefabProp.objectReferenceValue = go;
//                    Debug.Log($"✅ 自動割当: {expectedName} に {go.name} を設定しました");
//                    break;
//                }
//            }
//        }

//        EditorGUI.EndProperty();
//    }

//    //  プロパティの高さを取得
//    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
//    {
//        // 2行使うため
//        return EditorGUIUtility.singleLineHeight * 2 + 4;
//    }
//}
//#endif