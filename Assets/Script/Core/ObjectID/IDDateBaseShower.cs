//using UnityEngine;
//using UnityEditor;
//using Kamatte.ID;

//namespace Kamatte.Core
//{
//    public class IDDatabaseEditorWindow : EditorWindow    //  IDデータベースのエディタ拡張クラス
//    {
//        [MenuItem("Tools/ID Datebase Tool")]
//        //  エディタウィンドウを表示
//        public static void ShowWindow()
//        {
//            GetWindow<IDDatabaseEditorWindow>("ID Database Tool");    //  エディタウィンドウ作成
//        }

//        void OnGUI()
//        {
//            GUILayout.Label("ID Database Utility", EditorStyles.boldLabel);    //  ウィンドウラベル決定

//            if (GUILayout.Button("Show all ids"))    //  ボタン作成
//            {
//                try
//                {
//                    IDShower.ShowObjID();    //  オブジェクトIDを表示
//                }
//                catch (System.Exception ex)
//                {
//                    Debug.LogError($"✖オブジェクトID表示中にエラー発生✖: {ex.Message}\n{ex.StackTrace}");
//                }
//            }
//            if (GUILayout.Button("Create Id datebase"))
//            {
//                try
//                {
//                    //  IDDateBase作成
//                    IDDataBaseCreater.BuildDatabase();
//                }
//                catch (System.Exception ex)
//                {
//                    Debug.LogError($"✖IDDateBase作成中にエラー発生: {ex.Message}\n{ex.StackTrace}");
//                }
//            }
//        }
//    }
//}