using Kamatte.Core;
using Kamatte.SwordCatch;
using UnityEngine.InputSystem;

namespace Kamatte.Player
{
    public class PlayerInputAction_SwordCatch    //  プレイヤーの白刃取り状態の入力に反応した動き
    {
        readonly StateHolder _stateHolder;
        public PlayerInputAction_SwordCatch(StateHolder stateHolder)
        {
            _stateHolder = stateHolder;
        }

        public void Catch(InputAction.CallbackContext context)    //  キャッチ挙動を開始する
        {
            if (!_stateHolder.IsHitSwing)
            {
                ServiceLocator.Resolve<AnimParamFacadeBase>().PlayerParam.Catch();
            }
        }

    }
}