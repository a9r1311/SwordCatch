using UnityEngine;
using UAssert = UnityEngine.Assertions.Assert;
using SwordCatch.Core;

namespace SwordCatch.Effect
{
    [DisallowMultipleComponent]
    public sealed class StageEffectGenerater : MonoBehaviour
    {
        [SerializeField] StateHolder _stateHolder;  // ゲーム状態を保持するクラス
        EffectSystem _effectSystem;  // エフェクト管理クラス

        [SerializeField] int _fireWorkGenerateCount = 5;
        [SerializeField] int _lightningGenerateLine = 20;

        void Awake()
        {
            UAssert.IsNotNull(_stateHolder, "StateHolderがインスペクターに設定されていません。");
        }

        void Start()
        {
            _effectSystem = ServiceLocator.Get<EffectSystem>();
        }
        public void OnCountChanged()
        {
            if (_stateHolder.CatchSuccessCnt == _fireWorkGenerateCount)
            {
                MyLogger.Log("花火発生");
                _effectSystem.Play(new EffectKey(GameMode.SwordCatch, EffectID.FireWorks));
            }

            if (_stateHolder.CatchSuccessCnt > _lightningGenerateLine)
            {
                MyLogger.Log("雷発生");
                _effectSystem.Play(new EffectKey(GameMode.SwordCatch, EffectID.Lightning));
            }
        }
    }
}