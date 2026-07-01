using Kamatte.Player;
using UnityEngine;

namespace Kamatte.Core
{
    public class PlayerTryCatchState : StateBase<PlayerSwordCatchStateID>    //  白刃取りIdle状態
    {
        PlayerHitBox _playerHitBoxManager;    //  ヒットボックスマネージャー

        public PlayerTryCatchState(PlayerHitBox hitBoxManager, IStateMachine<PlayerSwordCatchStateID> machine) : base(machine)
        {
            _playerHitBoxManager = hitBoxManager;
        }

        public override void OnEnter()
        {
            //_playerHitBoxManager.EnableHitBox(HitBoxID.SwordCatch);
        }

        public override void OnUpdate()
        {
            Debug.Log(4);
            _playerHitBoxManager.Update();
        }
    }
}