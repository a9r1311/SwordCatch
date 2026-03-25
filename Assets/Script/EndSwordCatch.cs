using UnityEngine;

namespace Kamatte.Core
{
    public class EndSwordCatch : StateMachineBehaviour
    {
        private bool _passed = false;
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (stateInfo.normalizedTime >= 1f && !_passed)
            {
                _passed = true;
                ServiceLocator.Resolve<GameModeAPIFacadeBase>().executeTask.Execute(GameMode.SwordCatch, GameMode.SwordCatch);
            }
        }
    }
}