using UnityEngine.InputSystem;
using SwordCatch.Core;
using SwordCatch.Animation;

namespace SwordCatch.Player
{
    //  プレイヤーの白刃取り状態の入力に反応した動き
    public sealed class PlayerInputAction
    {
        readonly StateHolder _stateHolder;
        AnimParamFacade _animParamFacade;
        
        public PlayerInputAction(StateHolder stateHolder)
        {
            _stateHolder = stateHolder;
            _animParamFacade = ServiceLocator.Get<AnimParamFacade>();
        }

        //  キャッチ挙動を開始する
        public void Catch(InputAction.CallbackContext context)
        {
            if (!_stateHolder.IsHitSwing)
            {
                _animParamFacade.PlayerParam.Catch();
            }
        }
    }
}