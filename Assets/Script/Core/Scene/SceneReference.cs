using UnityEngine;

namespace SwordCatch.Core
{
    //  シーン名を取得するためのクラス
    [System.Serializable]
    public sealed class SceneReference
    {
        [SerializeField] string _scenePath = string.Empty;
        public string ScenePath => _scenePath;

#if UNITY_EDITOR
        [SerializeField] UnityEditor.SceneAsset _sceneAsset;

        public void OnValidate()
        {
            if (_sceneAsset != null)
            {
                string path = UnityEditor.AssetDatabase.GetAssetPath(_sceneAsset);
                
                if (!string.IsNullOrEmpty(path))
                {
                    _scenePath = path;
                }
            }
            else
            {
                _scenePath = string.Empty;
            }
        }
#endif
    }
}