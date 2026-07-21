using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace SwordCatch.Core
{
    public class SceneMgr
    {
        // 検索を高速化するための辞書
        private readonly Dictionary<GameMode, SceneReference> _sceneMap = new();

        public SceneMgr(SceneMapping data)
        {
            foreach (var mapping in data.Mappings)
            {
                _sceneMap[mapping.Mode] = mapping.Scene;
            }
        }

        //  シーン読み込み
        public void LoadScene(GameMode mode)
        {
            if (_sceneMap.TryGetValue(mode, out var sceneRef))
            {
                SceneManager.LoadScene(sceneRef.ScenePath);
            }
            else
            {
                MyLogger.ErrorLog($"ゲームモード {mode} に対応するシーンが見つかりません。");
            }
        }
    }
}