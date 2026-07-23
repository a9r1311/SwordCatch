using SwordCatch.Core;
using SwordCatch.Effect;
using SwordCatch.HitBox;
using SwordCatch.Audio;
using SwordCatch.Animation;
using UnityEngine;

namespace SwordCatch.Player
{
    //  プレイヤーコントローラー
    [DisallowMultipleComponent]
    [RequireComponent(typeof(PlayerBootstrap))]
    public sealed class PlayerController : MonoBehaviour
    {
        StateHolder _stateHolder;  // ゲーム状態を保持するクラス
        PlayerHitBox _playerHitBoxMgr;  // プレイヤーヒットボックス管理クラス
        
        StageEffectGenerater _stageEffectGenerater;  // ステージエフェクト生成クラス

        AudioClip catchClip;  // 白刃取り成功時の音
        bool _isActivateOnCatch = false;  // キャッチ成功処理が複数回発生するのを防ぐためのフラグ

        AudioManager _audioManager;  // audio管理クラス
        EffectSystem _effectSystem;  // エフェクト管理クラス
        AnimParamFacade _animParamFacade;  // アニメーションパラメータ管理クラス

        //  初期化
        public void Initialize(PlayerContext ctx)
        {
            _playerHitBoxMgr = ctx.HitBoxMgr;
            _stateHolder = ctx.StateHolder;
            _stageEffectGenerater = ctx.StageEffectGenerater;

            catchClip = ctx.CatchSE;

            _audioManager = ServiceLocator.Get<AudioManager>();
            _effectSystem = ServiceLocator.Get<EffectSystem>();
            _animParamFacade = ServiceLocator.Get<AnimParamFacade>();
        }

        void Update()
        {
            _playerHitBoxMgr.Update();
        }

        //  当たり判定アクティブ
        public void ActiveHitBox()
        {
            _playerHitBoxMgr.EnableHitBox(HitBoxID.CatchSword);
        }

        //  当たり判定消去
        public void EraseHitBox()
        {
            _playerHitBoxMgr.DisableHitBox(HitBoxID.CatchSword);
            _isActivateOnCatch = false;
        }

        //  白刃取り成功
        public void OnCatch()
        {
            _stateHolder.CatchSuccess();

            if (_stateHolder.IsCatchSword && !_isActivateOnCatch)
            {
                MyLogger.Log("白刃取り成功");

                _isActivateOnCatch = true;

                _stageEffectGenerater.OnCountChanged();
                _audioManager.PlaySE(catchClip, 0.8f, 1f, 0f);
                _effectSystem.Play(new EffectKey(GameMode.SwordCatch, EffectID.CatchSword));
                _animParamFacade.SwingerParam.IsCought(true);
            }
        }

        void OnDrawGizmos()
        {
            if (_playerHitBoxMgr != null)
            {
                _playerHitBoxMgr.DrawGizmos();
            }
        }
    }
}