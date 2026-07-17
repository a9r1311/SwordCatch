using System;
using UnityEngine;


namespace Kamatte.Core
{
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
                ServiceLocator.Get<GameModeAPIFacade>().executeTask.Execute(GameMode.SwordCatch, GameMode.SwordCatch);
            }
        }
    }
}