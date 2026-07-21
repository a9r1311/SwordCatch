using SwordCatch.Animation;
using SwordCatch.Audio;
using SwordCatch.Core;
using SwordCatch.Effect;
using SwordCatch.HitBox;
using UnityEngine;

namespace SwordCatch.Player
{
    //  プレイヤーコントローラー
    [DisallowMultipleComponent]
    [RequireComponent(typeof(PlayerBootstrap))]
    public sealed class PlayerController : MonoBehaviour
    {
        PlayerHitBox _playerHitBoxMgr;  // プレイヤーヒットボックス管理クラス
        StateHolder _stateHolder;  // ゲーム状態を保持するクラス

        AudioManager _audioManager;  // audio管理クラス
        AudioClip catchClip;  // 白刃取り成功時の音
        bool _isActivateOnCatch = false;  // SEが何回もなるのを防ぐためのフラグ

        EffectSystem _effectSystem;

        //  初期化
        public void Initialize(PlayerContext ctx)
        {
            _playerHitBoxMgr = ctx.HitBoxMgr;
            _stateHolder = ctx.StateHolder;

            catchClip = ctx.CatchSE;
            _audioManager = ServiceLocator.Get<AudioManager>();

            _effectSystem = ServiceLocator.Get<EffectSystem>();
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

                _audioManager.PlaySE(catchClip, 0.8f, 1f, 0f);
                PlayrRandomEffect();
                _effectSystem.Play(new EffectKey(GameMode.SwordCatch, EffectID.CatchSword));
                ServiceLocator.Get<AnimParamFacade>().SwingerParam.IsCought(true);
            }
        }

        void PlayrRandomEffect()
        {
            if (_stateHolder.CatchSuccessCnt == 5)
            {
                _effectSystem.Play(new EffectKey(GameMode.SwordCatch, EffectID.FireWorks));
            }
            if (_stateHolder.CatchSuccessCnt > 20)
            {
                _effectSystem.Play(new EffectKey(GameMode.SwordCatch, EffectID.Lightning));
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