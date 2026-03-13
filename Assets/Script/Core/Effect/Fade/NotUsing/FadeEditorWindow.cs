//using UnityEngine;
//using UnityEditor;

//namespace Kamatte.Core
//{
//    public class FadeImageEditorWindow : EditorWindow
//    {
//        [MenuItem("Tools/Fade Tool")]

//        //  エディタウィンドウを表示
//        public static void ShowWindow()
//        {
//            GetWindow<FadeImageEditorWindow>("Fade Image Editor");
//        }

//        void OnGUI()
//        {
//            GUILayout.Label("Fade Image Editor", EditorStyles.boldLabel);

//            if (GUILayout.Button("Apply Scaling And Position To FadeImage in Scene"))
//            {
//                try
//                {
//                    FadeImageSetter.SettingSceneFadeImage();    //  四隅からくる闇のイメージを設定をシーンとアセット内に適用
//                }
//                catch (System.Exception ex)
//                {
//                    LogUtility.Log(LogPrefix.FadeImageEditorWindow, $"FadeImage設定適用時に例外発生: {ex.Message}\n{ex.StackTrace}", LogLevel.Error);
//                }
//            }
//        }
//    }
//}