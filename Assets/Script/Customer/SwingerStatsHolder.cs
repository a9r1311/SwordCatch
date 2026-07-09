using UnityEngine;
using System.Collections.Generic;

namespace Kamatte.SwordCatch
{
    [CreateAssetMenu(fileName = "SwingerStatList", menuName = "Swinger/StatList")]
    //  スウィンガーの能力値
    public sealed class SwingerStatsHolder : ScriptableObject, ISerializationCallbackReceiver
    {
        //  敵のIDと能力値のクラス
        [System.Serializable]
        public class SwingerIDStat
        {
            public SwingerID ID;  // ID
            public SwingerStatBlock Stat;  // 能力値
        }

        [Header("刀振りの能力値リスト")]
        [SerializeField] List<SwingerIDStat> _swingerIDStatList = new();    //  IDと能力値のリスト(インスペクター用)
        Dictionary<SwingerID, SwingerStatBlock> _statMap = new();    //  IDと能力値の辞書(処理用)

        public void OnAfterDeserialize()
        {
            //  能力値辞書の構築
            BuildStatMap();
        }
        public void OnBeforeSerialize() { }

        //  IDに応じた能力値の取得
        public SwingerStatBlock GetStat(SwingerID customerName)
        {
            return _statMap.TryGetValue(customerName, out SwingerStatBlock stat) ? stat : null;
        }

        //  能力値辞書の構築
        void BuildStatMap()
        {
            _statMap.Clear();
            foreach (var pair in _swingerIDStatList)
            {
                if (!_statMap.ContainsKey(pair.ID))
                {
                    _statMap.Add(pair.ID, pair.Stat);
                }
            }
        }
    }
}