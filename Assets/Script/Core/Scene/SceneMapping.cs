using System.Collections.Generic;
using UnityEngine;
using Kamatte.Core;

namespace SwordCatch.Core
{
    [CreateAssetMenu(fileName = "SceneMapping", menuName = "Utility/SceneMapping")]
    public sealed class SceneMapping : ScriptableObject
    {
        [System.Serializable]
        public struct Mapping
        {
            [Header("ゲームモードとシーンのマッピング")]
            public GameMode Mode;
            public SceneReference Scene;
        }

        public List<Mapping> Mappings;

#if UNITY_EDITOR
        void OnValidate()
        {
            if (Mappings == null) return;

            foreach (var mapping in Mappings)
            {
                mapping.Scene.OnValidate();
            }
        }
#endif
    }
}