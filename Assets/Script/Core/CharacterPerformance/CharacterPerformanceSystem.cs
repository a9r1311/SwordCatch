using System.Collections.Generic;
using UnityEngine;

namespace SwordCatch.CharacterPerformance
{
    //  演出用の動きをさせるシステム
    public sealed class CharacterPerformanceSystem
    {
        CharacterPerformanceCatalog _catalog;  // パフォーマンス定義データ集約カタログ
        Dictionary<Performer, GameObject> _actorMap;

        public CharacterPerformanceSystem(CharacterPerformanceCatalog catalog, Dictionary<Performer, GameObject> actorMap)
        {
            _catalog = catalog;
            _actorMap = actorMap;
        }

        //  パフォーマンス開始
        public void Play(PerformaceKey key)
        {
            var definition = _catalog.Get(key);
            if (definition == null)
            {
                Debug.LogWarning($"EffectDefinition not found : {key}");
                return;
            }

            //  演出用の動き開始開始
            definition.Execute(_actorMap[definition.Key.Performer]);
        }
    }
}