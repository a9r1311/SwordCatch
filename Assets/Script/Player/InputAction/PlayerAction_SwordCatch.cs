using Kamatte.Core;
using Kamatte.SwordCatch;
using UnityEngine.InputSystem;

namespace Kamatte.Player
{
    public class PlayerInputAction_SwordCatch    //  プレイヤーの白刃取り状態の入力に反応した動き
    {
        StateReader stateReader;
        
        public PlayerInputAction_SwordCatch(StateReader stateReader)
        {
            this.stateReader = stateReader;
        }

        public void Catch(InputAction.CallbackContext context)    //  キャッチ挙動を開始する
        {
            if (!stateReader.AcceseState().HitSwingState.IsHitSwing)
            {
                ServiceLocator.Resolve<AnimParamFacadeBase>().PlayerParam.PlayerParam_Catch.SetTrigger();
            }
        }

    }
}