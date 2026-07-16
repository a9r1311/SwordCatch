using System.Collections.Generic;
using UnityEngine;
using UAssert = UnityEngine.Assertions.Assert;

namespace Kamatte.Core
{
    //  演出用の動きをさせるシステムの初期化役
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(-10)]
    public sealed class CharacterPerformanceSystemBootstrap : MonoBehaviour
    {
        [Tooltip("演出用の動きのデータが入ってるScriptableObject")]
        [SerializeField] CharacterPerformanceCatalog _performaceCatalog;
        [Tooltip("パフォーマンサーと実際のオブジェクトの紐づけ")]
        [SerializeField] CharacterObjectBind[] _performancerObjectBind;

        CharacterPerformanceSystem _characterPerformanceSystem;

        void Awake()
        {
            UAssert.IsNotNull(_performaceCatalog, "PerformanceCatalogが未設定です");

            var map = new Dictionary<Performer, GameObject>(_performancerObjectBind.Length);

            foreach (var bind in _performancerObjectBind)
            {
                if (bind.CharacterOnScene != null)
                {
                    map[bind.Character] = bind.CharacterOnScene;
                }
            }

            _characterPerformanceSystem = new CharacterPerformanceSystem(_performaceCatalog, map);
            ServiceLocator.Register<CharacterPerformanceSystem>(_characterPerformanceSystem);
        }

        void OnDestroy()
        {
            ServiceLocator.Unregister<CharacterPerformanceSystem>();
        }
    }
}