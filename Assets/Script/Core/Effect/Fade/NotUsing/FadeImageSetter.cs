#if UNITY_EDITOR
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using Kamatte.ID;

namespace Kamatte.Core
{
    public class FadeImageSetter    //  Fadeの設定をする
    {
        public static void SettingSceneFadeImage()    //  シーン内のフェード用Imageの設定をする
        {
            GameObject[] fadeImages = FindSceneFadeImage();    //  シーン内のフェード用Imageを取得する

            int setCnt = 0;
            int totalTask = fadeImages.Length;
            const string ProgressTitle = "FadePlaneの設定適用中";
            const string ProgressMsg_Scene = "シーン:";
            //const string SetedImgMsg_Scene = "シーンのFadePlaneに設定適応:";

            try
            {
                foreach (GameObject fadeImage in fadeImages)
                {
                    float progress = (float)setCnt / totalTask;    //  進行度
                    //bool IsCanceled = ProgressBarUtility.ShowCancelable(ProgressTitle, ProgressMsg_Scene + fadeImage.name, progress);    //  キャンセルボタンが押されるかどうかのフラグ
                                                                                                                                         //  イメージ設定変更のプログレスバーを表示
                    //if (IsCanceled)
                    //{
                    //    break;
                    //}
                    //  設定適応
                    ApplySettings(fadeImage);
                    LogUtility.Log(LogPrefix.FadeImageSetter, "フェード用Imageの設定完了", LogLevel.Info);
                    setCnt++;
                }
            }
            finally
            {
                //  プログレスバー消去
                //ProgressBarUtility.Clear();
            }
            LogUtility.Log(LogPrefix.FadeImageSetter, $"フェード用Image設定適用完了。処理対象{setCnt}個のImage",LogLevel.Info);
        }

        static GameObject[] FindSceneFadeImage()    //  シーン内のFadePlaneを検索して取得
        {
            return Object.FindObjectsByType<IDGenerater>(FindObjectsSortMode.None)
                         .Where(obj =>
                              obj != null &&
                              obj.CategoryAsStringProperty == IDEnumToString.ToString(IDCategory.EFFECT) &&
                              obj.LabelAsStringProperty == IDEnumToString.ToString(IDLabel.FADE))
                         .Select(obj => obj.gameObject)
                         .ToArray();
        }

        static void ApplySettings(GameObject fadeImageObject)    //  Canvasに設定を適応する
        {
            if (!TryGetRequiredComponents(fadeImageObject, out RectTransform rectTransform, out Image image)) return;

            const string UndoLog = "Apply Setting To FadeImage";

            Undo.RecordObject(fadeImageObject, UndoLog);

            ApplyRectTransform(rectTransform);    //  レクトトランスフォームを設定

            LogUtility.Log(LogPrefix.FadeImageSetter, "PositionとScale設定完了", LogLevel.Info);
        }

        static void ApplyRectTransform(RectTransform rectTransform)    //  レクトトランスフォームの設定を適用する
        {
            rectTransform.anchorMin = Vector2.zero;               //  左下設定
            rectTransform.anchorMax = Vector2.one;                //  右上設定
            rectTransform.offsetMin = Vector2.zero;               //  左下のオフセット設定
            rectTransform.offsetMax = Vector2.zero;               //  右上のオフセット設定
            rectTransform.localRotation = Quaternion.identity;    //  回転設定
            rectTransform.anchoredPosition3D = Vector3.zero;      //  アンカーポジション設定
            rectTransform.localScale = Vector3.one;               //  ローカルスケール設定  
        }
        private static bool TryGetRequiredComponents(GameObject obj, out RectTransform rect, out Image img)    // 内部で必要なコンポーネントをチェック＆取得

        {
            rect = obj.GetComponent<RectTransform>();
            img = obj.GetComponent<Image>();
            return rect != null && img != null;
        }
    }
}
#endif