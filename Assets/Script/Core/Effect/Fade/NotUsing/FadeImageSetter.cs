#if UNITY_EDITOR
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using Kamatte.ID;

namespace Kamatte.Core
{
    //  Fadeの設定をする
    public sealed class FadeImageSetter
    {
        //  シーン内のフェード用Imageの設定をする
        public static void SettingSceneFadeImage()
        {
            //  シーン内のフェード用Imageを取得する
            GameObject[] fadeImages = FindSceneFadeImage();

            int setCnt = 0;
            int totalTask = fadeImages.Length;
            const string ProgressTitle = "FadePlaneの設定適用中";
            const string ProgressMsg_Scene = "シーン:";

            try
            {
                foreach (GameObject fadeImage in fadeImages)
                {
                    float progress = (float)setCnt / totalTask;    //  進行度

                    ApplySettings(fadeImage);
                    MyLogger.Log("フェード用Imageの設定完了");
                    setCnt++;
                }
            }
            finally
            {
                //  プログレスバー消去
                //ProgressBarUtility.Clear();
            }
            MyLogger.Log($"フェード用Image設定適用完了。処理対象{setCnt}個のImage");
        }

        //  シーン内のFadePlaneを検索して取得
        static GameObject[] FindSceneFadeImage()
        {
            return Object.FindObjectsByType<IDGenerater>(FindObjectsSortMode.None)
                         .Where(obj =>
                              obj != null &&
                              obj.CategoryAsStringProperty == IDEnumToString.ToString(IDCategory.EFFECT) &&
                              obj.LabelAsStringProperty == IDEnumToString.ToString(IDLabel.FADE))
                         .Select(obj => obj.gameObject)
                         .ToArray();
        }

        //  Canvasに設定を適応する
        static void ApplySettings(GameObject fadeImageObject)
        {
            if (!TryGetRequiredComponents(fadeImageObject, out RectTransform rectTransform, out Image image)) return;

            const string UndoLog = "Apply Setting To FadeImage";

            Undo.RecordObject(fadeImageObject, UndoLog);

            //  レクトトランスフォームを設定
            ApplyRectTransform(rectTransform);

            MyLogger.Log("Positionとscale設定完了");
        }

        //  レクトトランスフォームの設定を適用する
        static void ApplyRectTransform(RectTransform rectTransform)
        {
            rectTransform.anchorMin = Vector2.zero;               //  左下設定
            rectTransform.anchorMax = Vector2.one;                //  右上設定
            rectTransform.offsetMin = Vector2.zero;               //  左下のオフセット設定
            rectTransform.offsetMax = Vector2.zero;               //  右上のオフセット設定
            rectTransform.localRotation = Quaternion.identity;    //  回転設定
            rectTransform.anchoredPosition3D = Vector3.zero;      //  アンカーポジション設定
            rectTransform.localScale = Vector3.one;               //  ローカルスケール設定  
        }
        
        // 内部で必要なコンポーネントをチェック＆取得
        static bool TryGetRequiredComponents(GameObject obj, out RectTransform rect, out Image img)

        {
            rect = obj.GetComponent<RectTransform>();
            img = obj.GetComponent<Image>();
            return rect != null && img != null;
        }
    }
}
#endif