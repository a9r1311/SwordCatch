using System;
using UnityEngine;

namespace Kamatte.Core
{
    //  キャラクターパフォーマンスの一意Key
    [System.Serializable]
    public struct PerformaceKey : IEquatable<PerformaceKey>
    {
        [SerializeField] Performer _performancer;  // パフォーマンスをするキャラ
        [SerializeField] EffectActTrigger _performanceTrigger;  // パフォーマンスが始まる条件
        [SerializeField] PerformaceType _performanceType;   //  動きの種類

        public Performer Performer => _performancer;

        public PerformaceKey(
            Performer performancer,
            EffectActTrigger performanceTrigger,
            PerformaceType performanceType
            )
        {
            _performancer = performancer;
            _performanceTrigger = performanceTrigger;
            _performanceType = performanceType;
        }

        public override bool Equals(object obj) => obj is PerformaceKey other && Equals(other);

        public bool Equals(PerformaceKey obj)
        => obj is PerformaceKey other
        && _performancer == other._performancer
        && _performanceTrigger == other._performanceTrigger
        && _performanceType == other._performanceType;
        
        //  ハッシュコード取得
        public override int GetHashCode()
        {
            return HashCode.Combine(_performancer,  _performanceTrigger, _performanceType);
        }
    }
}