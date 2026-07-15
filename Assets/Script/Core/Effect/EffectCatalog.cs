using System.Linq;
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

        //  エフェクトデータ取得
        public EffectDefinition Get(EffectKey key)
        {
            _cache ??= _effects.ToDictionary(e => e.Key);
            return _cache[key];
        }
    }
}