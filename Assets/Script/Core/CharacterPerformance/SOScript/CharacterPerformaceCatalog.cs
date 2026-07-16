using System.Collections.Generic;
using UnityEngine;

namespace Kamatte.Core
{
    //  演出用の動きの定義データ集約クラス
    [CreateAssetMenu(fileName = "CharacterPerformanceCatalog", menuName = "Character/PerformaceCatalog")]
    public sealed class CharacterPerformanceCatalog : ScriptableObject
    {
        [Header("パフォーマンス定義データリスト")]
        [SerializeField] List<CharacterPerformanceDefBase> _performanceList;  // エフェクトデータリスト

        Dictionary<PerformaceKey, CharacterPerformanceDefBase> _cache;     //  エフェクトデータ辞書(内部処理用)

        void OnEnable()
        {
            _cache = null;
        }

        //  Performaceデータ取得
        public CharacterPerformanceDefBase Get(PerformaceKey key)
        {
            if (_cache == null)
            {
                _cache = new Dictionary<PerformaceKey, CharacterPerformanceDefBase>(_performanceList.Count);
                foreach (var item in _performanceList)
                {
                    if (item != null) _cache[item.Key] = item;
                }
            }

            return _cache.TryGetValue(key, out var def) ? def : null;
        }
    }
}