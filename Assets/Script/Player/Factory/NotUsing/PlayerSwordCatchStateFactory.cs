using Kamatte.Core;

namespace Kamatte.Player
{
    public class PlayerStateFacotry_SwordCatch : SMFactoryBase<PlayerSwordCatchStateID>    //  プレイヤーの白刃取り状態を生成するファクトリ
    {
        PlayerSwordCatchSM _playerSwordCatchStateMachine;    //  プレイヤーのステートマシーン
        PlayerHitBox _playerHitBoxMgr;                    //  プレイヤーの当たり判定管理クラス

        public PlayerStateFacotry_SwordCatch(PlayerHitBox playerHitBoxMgr, PlayerSwordCatchSM stateMachine)    //  コンストラクタ
        {
            _playerSwordCatchStateMachine = stateMachine;
            _playerHitBoxMgr = playerHitBoxMgr;

            Register(PlayerSwordCatchStateID.Idle, () => new PlayerIdleState_SwordCatch(_playerHitBoxMgr, _playerSwordCatchStateMachine, this));    //  State登録
            Register(PlayerSwordCatchStateID.TryCatch, () => new PlayerTryCatchState(_playerHitBoxMgr, _playerSwordCatchStateMachine));       //  State登録
        }
    }
}