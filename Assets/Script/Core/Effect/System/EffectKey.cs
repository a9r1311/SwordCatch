using SwordCatch.Core;
using System;
using UnityEngine;

namespace SwordCatch.Effect
{
    //  エフェクトの一意Key
    [System.Serializable]
    public struct EffectKey : IEquatable<EffectKey>
    {
        [SerializeField] GameMode _gameMode;     //  ゲームモード
        [SerializeField] EffectID _effectID;   //  エフェクトの種類

        public EffectKey(GameMode gameMode, EffectID effectID)
        {
            _gameMode = gameMode;
            _effectID = effectID;
        }

        public override bool Equals(object obj)
        {
            return obj is EffectKey other && Equals(other);
        }

        public bool Equals(EffectKey obj)
        => obj is EffectKey other
        && _gameMode == other._gameMode
        && _effectID == other._effectID;
    }
}