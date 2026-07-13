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
        bool _isActivateOnCatch = false;  // SEが何回もなるのを防ぐためのフラグ

        readonly Vector3 _starEffectPos = new Vector3(616.593f, -3.01f, 513.24f);
        readonly Vector3 _fireWorksPos = new Vector3(648, -507, 269);
        readonly Vector3 _lightningCenterPos = new Vector3(616, -5.5f, 507);

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
                EffectAPIWindow.Play(new EffectKey(GameMode.SwordCatch, EffectKind.CatchSword), _starEffectPos);
                ServiceLocator.Resolve<AnimParamFacadeBase>().SwingerParam.IsCought(true);
            }
        }

        void PlayrRandomEffect()
        {
            if (_stateHolder.CatchSuccessCnt == 5)
            {
                EffectAPIWindow.Play(new EffectKey(GameMode.SwordCatch, EffectKind.FireWorks), _fireWorksPos);
            }
            if (_stateHolder.CatchSuccessCnt > 20)
            {
                float radius = 7f;
                Vector3 LightningAddPos = Random.insideUnitSphere * radius;
                Vector3 LightningPos = new Vector3(_lightningCenterPos.x + LightningAddPos.x, _lightningCenterPos.y, _lightningCenterPos.z + LightningAddPos.z);
                EffectAPIWindow.Play(new EffectKey(GameMode.SwordCatch, EffectKind.Lightning), LightningPos);
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