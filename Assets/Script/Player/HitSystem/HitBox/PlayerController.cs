using UnityEngine;
using Kamatte.Core;
using Kamatte.SwordCatch;

namespace Kamatte.Player
{
    //  プレイヤーコントローラー
    [RequireComponent(typeof(PlayerBootstrap))]
    [DisallowMultipleComponent]
    public sealed class PlayerController : MonoBehaviour
    {
        PlayerHitBox _playerHitBoxMgr;    //  プレイヤーヒットボックス管理クラス

        public StateReader StateReader { get; private set; }
        public StateWriter StateWriter { get; private set; }

        AudioClip catchClip;
        bool isSound = false;

        public void Initialize(PlayerContext ctx)    //  初期化
        {
            _playerHitBoxMgr = ctx.HitBoxMgr;

            StateReader = ctx.StateReader;
            StateWriter = ctx.StateWriter;

            catchClip = ctx.CatchSE;
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
            if (StateReader.StateHolder.IsCatchSword && !isSound)
            {
                isSound = true;
                AudioManager.Instance.PlaySE(catchClip, 0.8f, 1f, 0f);
            }
        }

        //void OnDrawGizmos()
        //{
        //    if (playerHitBoxMgr.ActiveBox == null)
        //        return;

        //    // 中心座標を解決
        //    Vector3 center = playerHitBoxMgr.ResolveCenter(playerHitBoxMgr._playerHeadTF);
        //    Vector3 size = playerHitBoxMgr.ActiveBox.size;

        //    Gizmos.color = Color.red;
        //    Gizmos.matrix = Matrix4x4.TRS(center, playerHitBoxMgr._playerHeadTF.rotation, Vector3.one);
        //    Gizmos.DrawWireCube(Vector3.zero, size);
        //}
    }
}