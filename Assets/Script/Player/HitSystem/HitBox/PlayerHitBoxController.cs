using UnityEngine;
using Kamatte.Core;
using Kamatte.SwordCatch;

namespace Kamatte.Player
{
    [RequireComponent(typeof(PlayerHitBoxControllerBootstrap))]
    [DisallowMultipleComponent]
    public class PlayerHitBoxController : MonoBehaviour    //  プレイヤー制御クラス
    {
        PlayerHitBoxMgr playerHitBoxMgr;              //  プレイヤーヒットボックス管理クラス

        public StateReader_SwordCatch StateReader { get; private set; }
        public StateWriter_SwordCatch StateWriter { get; private set; }

        private AudioSource audioSource;
        private AudioClip catchClip;
        bool isSound = false;

        public void Initialize(PlayerContext ctx)    //  初期化
        {
            playerHitBoxMgr = ctx.HitBoxMgr;

            StateReader = ctx.StateReader;
            StateWriter = ctx.StateWriter;

            audioSource = ctx.AudioSource;
            catchClip = ctx.CatchSE;
        }

        void Update()
        {
            playerHitBoxMgr.Update();
        }

        public void ActiveHitBox()
        {
            playerHitBoxMgr.EnableHitBox(HitBoxID.SwordCatch);
        }

        public void EraseHitBox()
        {
            playerHitBoxMgr.DisableHitBox(HitBoxID.SwordCatch);
            isSound = false;
        }

        public void PlayCatchSound()
        {
            if (StateReader.AcceseState().CatchState.IsCatchSword && !isSound)
            {
                isSound = true;
                audioSource.PlayOneShot(catchClip, 0.6f);
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