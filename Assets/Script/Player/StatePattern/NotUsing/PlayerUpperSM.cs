using Kamatte.Player;
using UnityEngine;

namespace Kamatte.Core
{
    public class PlayerUpperSM : StateMachineBase<PlayerStateMachineID>    //  プレイヤーの上位ステートマシーン
    {
        IStateFactory<PlayerStateMachineID> _stateMachineFactory;    

        public PlayerUpperSM()    //  コンストラクタ
        {  }

        public override void Initialize(IStateFactory<PlayerStateMachineID> stateMachineFactory)    //  初期化
        {
            _stateMachineFactory = stateMachineFactory;

            ChangeState(_stateMachineFactory.CreateState(PlayerStateMachineID.SwordCatchSM));
        }

        public override void Update()
        {
            Debug.Log("deroa");
            base.Update();
        }
    }
}