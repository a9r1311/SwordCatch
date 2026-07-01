using Kamatte.Player;
namespace Kamatte.Core
{
    public class PlayerIdleState_SwordCatch : StateBase<PlayerSwordCatchStateID>    //  白刃取りIdle状態
    {
        PlayerHitBox _playerHitBoxMgr;
        IStateFactory<PlayerSwordCatchStateID> _stateFactory;

        public PlayerIdleState_SwordCatch(PlayerHitBox hitBoxManager, IStateMachine<PlayerSwordCatchStateID> machine, IStateFactory<PlayerSwordCatchStateID> stateFactory)    //  コンストラクタ
            : base(machine)
        {
            _playerHitBoxMgr = hitBoxManager;
            _stateFactory = stateFactory;
        }

        public override void OnEnter()
        {
            SwordCatchEventBus.OnCatchPressed += () => _machine.ChangeState(_stateFactory.CreateState(PlayerSwordCatchStateID.TryCatch)); 
        }
        public override void OnUpdate()
        {
            
        }
    }
}