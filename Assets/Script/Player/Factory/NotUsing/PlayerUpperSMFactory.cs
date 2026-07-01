using Kamatte.Core;

namespace Kamatte.Player
{
    public class PlayerUpperSMFactory : SMFactoryBase<PlayerStateMachineID>    //  プレイヤー上位ステートマシーン生成
    {
        PlayerUpperSM _upperStateMachine;    //  アッパーステートマシーン(//　ここから)
        PlayerHitBox _hitBoxMamager;    //  ヒットボックスマネージャー

        public PlayerUpperSMFactory(PlayerHitBox hitBoxMgr)    //  コンストラクタ
        {
            _hitBoxMamager = hitBoxMgr;
            Register(PlayerStateMachineID.SwordCatchSM, () => CreateSwordCatchSM());    //  ステートマシーン登録
        }

        private IState<PlayerStateMachineID> CreateSwordCatchSM()    //  白刃取りステートマシーン生成
        {
            var swordCatchSM = new PlayerSwordCatchSM();
            var swordCatchSMFactory = new PlayerStateFacotry_SwordCatch(_hitBoxMamager, swordCatchSM);

            swordCatchSM.Initialize(swordCatchSMFactory);    //  ステートマシーン初期化

            return swordCatchSM;
        }
    }
}