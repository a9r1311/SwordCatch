using UnityEngine;
using Kamatte.Core;
using Kamatte.SwordCatch;

namespace Kamatte.Player
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
        bool isSound = false;  // SEが何回もなるのを防ぐためのフラグ

        //  初期化
        public void Initialize(PlayerContext ctx)
        {
            _playerHitBoxMgr = ctx.HitBoxMgr;
            _stateHolder = ctx.StateHolder;

            catchClip = ctx.CatchSE;
            _audioManager = ServiceLocator.Resolve<AudioManager>();
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
            isSound = false;
        }

        //  白刃取り成功
        public void OnCatch()
        {
            if (_stateHolder.IsCatchSword && !isSound)
            {
                isSound = true;
                _audioManager.PlaySE(catchClip, 0.8f, 1f, 0f);
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