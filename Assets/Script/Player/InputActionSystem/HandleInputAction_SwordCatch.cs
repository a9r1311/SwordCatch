
namespace SwordCatch.Player
{
    public class HandleInputAction_SwordCatch    //  プレイヤーの入力を受けつけるクラス
    {
        InputSystem_Actions inputSystem_Action;

        PlayerInputAction_SwordCatch playerAction_SwordCatch;    //  プレイヤーの白刃取り状態のアクション

        public HandleInputAction_SwordCatch(InputSystem_Actions inputSystem, PlayerInputAction_SwordCatch action)
        {
            inputSystem_Action = inputSystem;
            playerAction_SwordCatch = action;

            SetReaction();
        }

        void SetReaction()
        {
            inputSystem_Action.Player.Enable();
            inputSystem_Action.Player.Catch.started += playerAction_SwordCatch.Catch;
        }

        public void SetOffReaction()
        {
            inputSystem_Action.Player.Catch.started -= playerAction_SwordCatch.Catch;
            inputSystem_Action.Player.Disable();
        }
    }
}