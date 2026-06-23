#if UNITY_EDITOR
using UnityEditor;

namespace Kamatte.Editor
{
    //  プログレスバーUtility
    public static class ProgressBarUtility
    {
        //  構造体を生成
        public static ProgressBarScope Open(string title, string message, bool isCancelable = true)
        {
            return new ProgressBarScope(title, message, isCancelable);
        }
    }

    //  プログレスバー構造体
    public readonly ref struct ProgressBarScope
    {
        readonly string _title;
        readonly string _message;
        readonly bool _isCancelable;

        public ProgressBarScope(string title, string message, bool isCancelable = true)
        {
            _title = title;
            _message = message;
            _isCancelable = isCancelable;

            if (isCancelable)
            {
                EditorUtility.DisplayCancelableProgressBar(_title, _message, 0f);
            }
            else
            {
                EditorUtility.DisplayProgressBar(_title, _message, 0f);
            }
        }

        //  進行度を更新する
        public bool UpdateProgress(float progress)
        {
            if(_isCancelable)
            {
                return EditorUtility.DisplayCancelableProgressBar(_title, _message, progress);
            }
            else
            {
                EditorUtility.DisplayProgressBar(_title, _message, progress);
                return false;
            }
        }

        //  プログレスバー消去(IDisposableのパターンベース)
        public void Dispose()
        {
            EditorUtility.ClearProgressBar();
        }
    }
}
#endif