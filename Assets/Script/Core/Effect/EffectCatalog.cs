using System.Collections.Generic;
using UnityEngine;

namespace Kamatte.Core
{
    //  エフェクト定義データを集約しているクラス
    [CreateAssetMenu(fileName = "EffectDefinitionCatalog", menuName = "Effect/Catalog")]
    public sealed class EffectCatalog : ScriptableObject
    {
        [SerializeField] List<EffectDefinition> _effects;  // エフェクト定義データリスト(インスペクター用)

        Dictionary<EffectKey, EffectDefinition> _cache;  // エフェクトデータ辞書(内部処理用)

        void OnEnable()
        {
            _cache = null;
        }

        //  エフェクトデータ取得
        public EffectDefinition Get(EffectKey key)
        {
            if (_cache == null)
            {
                _cache = new Dictionary<EffectKey, EffectDefinition>(_effects.Count);
                
                foreach (var effect in _effects)
                {
                    _cache[effect.Key] = effect;
                }
            }

            return _cache.TryGetValue(key, out var definition) ? definition : null;
        }
    }
}