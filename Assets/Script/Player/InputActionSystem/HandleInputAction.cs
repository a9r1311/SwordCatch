namespace SwordCatch.Player
{
    //  プレイヤーの入力を受けつけるクラス
    public sealed class HandleInputAction
    {
        InputSystem_Actions inputSystem_Action;

        //  プレイヤーの白刃取り状態のアクション
        PlayerInputAction playerAction_SwordCatch;

        public HandleInputAction(InputSystem_Actions inputSystem, PlayerInputAction action)
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