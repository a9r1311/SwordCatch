using UnityEngine.SceneManagement;
using System;

namespace Kamatte.Core
{
    public static class SceneUtility    //  シーンユーティリティ
    {
        public static void LoadScene(string sceneName, Action onCompleted = null)    //  シーンを読み込み
        {
            if (string.IsNullOrEmpty(sceneName))
            {
                MyLogger.Log($"指定シーン名がEmptyです。 シーン名 : {sceneName}");
                return;
            }

            SceneManager.LoadSceneAsync(sceneName).completed += _ =>
            {
                MyLogger.Log($"シーン読み込み完了。 シーン名 : {sceneName}");
                onCompleted?.Invoke();
            };
        }

        public static void LoadSceneAdditive(string sceneName, Action onCompleted = null)    //  シーン読み込み(シーン破棄しない)
        {
            if (string.IsNullOrEmpty(sceneName))
            {
                MyLogger.Log($"シーン読み込み完了。 シーン名 : {sceneName}");
                return;
            }

            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive).completed += _ =>
            {
                MyLogger.Log($"シーン読み込み完了。 シーン名 : {sceneName}");
                onCompleted?.Invoke();
            };
        }

        public static string GetActiveSceneName()    //  現在のシーンの名前を返す
        {
            return SceneManager.GetActiveScene().name;
        }

        public static void ReloadActiveScene(Action onCompleted = null)    //  現在のシーンをリロードする
        {
            string sceneName = GetActiveSceneName();
            LoadScene(sceneName, onCompleted);
        }

        public static bool IsSceneLoaded(string sceneName)
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if (scene.name == sceneName && scene.isLoaded)
                {
                    return true;
                }
            }
            return false;
        }

        public static void UnloadScene(string sceneName, Action onCompleted = null)
        {
            if (!IsSceneLoaded(sceneName))
            {
                MyLogger.WarningLog($"アンロード対象がロードされていません : {sceneName}");
                return;
            }

            SceneManager.UnloadSceneAsync(sceneName).completed += _ =>
            {
                MyLogger.Log($"シーンアンロード完了 : {sceneName}");
                onCompleted?.Invoke();
            };
        }
    }
}