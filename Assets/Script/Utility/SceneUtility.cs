using UnityEngine;
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
                LogUtility.Log(LogPrefix.SceneUtility, "シーン名が空です", LogLevel.Error);
                return;
            }

            SceneManager.LoadSceneAsync(sceneName).completed += _ =>
            {
                LogUtility.Log(LogPrefix.SceneUtility, $"シーン読み込み完了: {sceneName}", LogLevel.Info);
                onCompleted?.Invoke();
            };
        }

        public static void LoadSceneAdditive(string sceneName, Action onCompleted = null)    //  シーン読み込み(シーン破棄しない)
        {
            if (string.IsNullOrEmpty(sceneName))
            {
                Debug.LogError("");
                LogUtility.Log(LogPrefix.SceneUtility, $"シーン読み込み完了: {sceneName}", LogLevel.Info);
                return;
            }

            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive).completed += _ =>
            {
                LogUtility.Log(LogPrefix.SceneUtility, $"Additive読み込み完了: {sceneName}", LogLevel.Info);
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
                Debug.LogWarning($"[SceneUtility] アンロード対象シーンがロードされていません: {sceneName}");
                return;
            }

            SceneManager.UnloadSceneAsync(sceneName).completed += _ =>
            {
                Debug.Log($"[SceneUtility] シーンアンロード完了: {sceneName}");
                onCompleted?.Invoke();
            };
        }
    }
}