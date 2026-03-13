using System.Collections.Generic;
using UnityEngine;

namespace Kamatte.Core
{
    public class EffectActSystem : MonoBehaviour, IEffectActSystem    //  演出用の動きをさせるクラス
    {
        EffectActCatalog _catalog;    //  演出用動きSOカタログ
        Dictionary<EffectActor, GameObject> _actorMap;
        private void Awake()
        {
            ServiceLocator.Register<IEffectActSystem>(this);    // ServiceLocator に自分を登録
        }

        private void OnDestroy()
        {
            //ServiceLocator.Unregister<IEffectSystem>();    // シーン破棄時に解除(Unregisterの必要性ないかも)
        }

        //  --  Public API

        public void Initialize(EffectActCatalog catalog, Dictionary<EffectActor, GameObject> actorMap)    //  BootStrapから呼ばれる初期化
        {
            _catalog = catalog;
            _actorMap = actorMap;
        }

        public void Play(EffectActKey key)    //  エフェクト再生
        {
            // 定義解決
            var definition = _catalog.Get(key);
            if (definition == null)
            {
                Debug.LogWarning($"EffectDefinition not found : {key}");
                return;
            }

            definition.Execute(_actorMap[definition.EffectActKey.EffectActor]);    //  演出用アクション開始
        }
    }
}