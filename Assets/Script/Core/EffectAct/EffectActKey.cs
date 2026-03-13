using System;
using UnityEngine;

namespace Kamatte.Core
{
    [System.Serializable]
    public struct EffectActKey    //  演出用の動きの種類
    {
        [SerializeField] private EffectActor _effectActor;   //  エフェクトの対象
        [SerializeField] private EffectActTrigger _effectactTrigger;   //  演じるオブジェクト
        [SerializeField] private EffectActType _effectActType;   //  動きの種類

        //  --  public API

        public EffectActor EffectActor => _effectActor;   //  演じる対象

        public EffectActKey(EffectActor effectActor, EffectActTrigger effectActTrigger, EffectActType effectActType)    //  コンストラクタ
        {
            _effectActor = effectActor;
            _effectactTrigger = effectActTrigger;
            _effectActType = effectActType;
        }

        public override bool Equals(object obj)    //  等価比較演算子
        => obj is EffectActKey other
        && _effectActor == other._effectActor
        && _effectactTrigger == other._effectactTrigger
        && _effectActType == other._effectActType;

        public override int GetHashCode()    //  ハッシュコード取得
        {
            return HashCode.Combine(_effectActor,  _effectactTrigger, _effectActType);
        }
    }
}