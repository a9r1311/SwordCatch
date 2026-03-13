using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Kamatte.Core
{
    [CreateAssetMenu(fileName = "EffectActCatalog", menuName = "EffectAct/Catalog")]
    public class EffectActCatalog : ScriptableObject    //  演出用動きのSO集約SO
    {
        [Header("演出用動きデータ一覧")]
        [SerializeField] List<EffectActDef> _effects;    //  エフェクトデータリスト

        Dictionary<EffectActKey, EffectActDef> _cache;     //  エフェクトデータ辞書(内部処理用)

        //  --  Public API

        public EffectActDef Get(EffectActKey key)    //  エフェクトデーター取得
        {
            _cache ??= _effects.ToDictionary(e => e.EffectActKey);
            return _cache[key];
        }
    }
}