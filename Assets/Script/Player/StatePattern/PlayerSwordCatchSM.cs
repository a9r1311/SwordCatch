using Kamatte.Player;
using UnityEngine;

namespace Kamatte.Core
{
    public class PlayerSwordCatchSM : StateMachineBase<PlayerSwordCatchStateID>, IState<PlayerStateMachineID>    //  白刃取り状態のプレイヤーステートマシーン
    {
        PlayerStateFacotry_SwordCatch _playerSwordCatchSMFactory;    //  上位ステートマシーン
        public PlayerSwordCatchSM()    //  コンストラクタ
        {
        }

        public override void Initialize(IStateFactory<PlayerSwordCatchStateID> stateFactory)    //  初期化
        {
            _playerSwordCatchSMFactory = stateFactory as PlayerStateFacotry_SwordCatch;

            Debug.Log(_playerSwordCatchSMFactory.CreateState(PlayerSwordCatchStateID.Idle));
            ChangeState(_playerSwordCatchSMFactory.CreateState(PlayerSwordCatchStateID.Idle));    //  Idle状態に変更
        }

        public override void ChangeState(IState<PlayerSwordCatchStateID> nextState)     //  状態変更
        {
            base.ChangeState(nextState);
        }

        public override void OnUpdate()    //  ステート中の処理
        {
            _currentState.OnUpdate();
        }
    }
}