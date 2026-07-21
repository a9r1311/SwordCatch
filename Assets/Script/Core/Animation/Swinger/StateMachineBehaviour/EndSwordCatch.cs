using SwordCatch.Core;
using System;
using UnityEngine;

namespace SwordCatch.Animation
{
    //  白刃取りの終了トリガー
    public sealed class EndSwordCatch : StateMachineBehaviour
    {
        public event Action OnAnimationFinished;    //  アニメーション終了通知用

        bool _isEndSwordCatch = false;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _isEndSwordCatch = false;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (stateInfo.normalizedTime >= 1f && ! _isEndSwordCatch)
            {
                _isEndSwordCatch = true;
                MyLogger.Log("白刃取り失敗!");
                ServiceLocator.Get<CoroutineRunner>().StartCoroutine(
                    ServiceLocator.Get<GameModeChangeTask>().Execute(GameMode.SwordCatch, GameMode.SwordCatch)
                    );
            }
        }
    }
}