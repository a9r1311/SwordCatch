using UnityEngine;
using Kamatte.Core;
using Kamatte.SwordCatch;

namespace Kamatte.Player
{
    public class StartCatchAnimation : IPlayerCommand    //  刀取りアクション
    {
        Animator _playerAnimator;         //  プレイヤーアニメター
        public StartCatchAnimation(Animator playerAnimator)    //  コンストラクタ
        {
            _playerAnimator = playerAnimator;
        }

        public void Execute()    //  刀取り行動実行
        {
            StartAnimation();
        }

        void StartAnimation()    //  刀を取るアニメーションを開始
        {
            LogUtility.Log(LogPrefix.PlayerController, "刀取りモーション開始", LogLevel.Debug);
            _playerAnimator.SetTrigger(SwordCatchAnimHash_Player.GetAnimation(SwordCatchAnimID_Player.CatchSword));
        }
    }
}