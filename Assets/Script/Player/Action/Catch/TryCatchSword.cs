using UnityEngine;
using Kamatte.SwordCatch;

namespace Kamatte.Player
{
    //  刀取りアクション
    public sealed class StartCatchAnimation : IPlayerCommand
    {
        readonly Animator _playerAnimator;         //  プレイヤーアニメター
        public StartCatchAnimation(Animator playerAnimator)
        {
            _playerAnimator = playerAnimator;
        }

        //  刀取り行動実行
        public void Execute()
        {
            //  白刃取りアニメーション開始
            StartAnimation();
        }

        //  刀を取るアニメーションを開始
        void StartAnimation()
        {
            Debug.Log("刀取りモーション開始");
            _playerAnimator.SetTrigger(SwordCatchAnimHash_Player.GetAnimation(SwordCatchAnimID_Player.CatchSword));
        }
    }
}