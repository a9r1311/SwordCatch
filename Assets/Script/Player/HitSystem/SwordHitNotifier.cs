using UnityEngine;
using UAssert = UnityEngine.Assertions.Assert;
using Kamatte.Core;
using Kamatte.Player;

namespace Kamatte.SwordCatch
{
    //  刀が当たった時の処理をするクラス
    [DisallowMultipleComponent]
    public sealed class SwordHitNotifier : MonoBehaviour
    {
        [SerializeField] PlayerController _playerController;
        [SerializeField] StateHolder _stateHolder;  // ゲーム状態を保持しているクラス

        AnimParamFacade _animationFacade;

        void Awake()
        {
            UAssert.IsNotNull(_playerController, " playerContorollerが未設定です");
            UAssert.IsNotNull(_stateHolder, "stateHolderが未設定です");
        }

        void Start()
        {
            _animationFacade = ServiceLocator.Resolve<AnimParamFacade>();
        }

        //  刀が当たった時の処理
        public void OnSwordHit(Collider other)
        {
            if (!other.CompareTag("Sword")) return;

            if (!_stateHolder.IsCatchSword)
            {
                _playerController.EraseHitBox();
                _stateHolder.IsHitSwing = true;
                EffectActAPI.Action(new EffectActKey(EffectActor.Player, EffectActTrigger.Hit, EffectActType.Blow));
                _animationFacade.SwingerParam.IsHit(true);
            }
        }
    }
}