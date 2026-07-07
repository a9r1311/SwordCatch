using UnityEngine;
using UAssert = UnityEngine.Assertions.Assert;
using Kamatte.Core;
using Kamatte.Player;

namespace Kamatte.SwordCatch
{
    [DisallowMultipleComponent]
    public sealed class SwordHitNotifier : MonoBehaviour    //  刀が当たった時に処理を動かす
    {
        [SerializeField] PlayerController _playerController;
        [SerializeField] StateHolder _stateHolder;

        AnimParamFacadeBase _animationFacade;

        void Awake()
        {
            UAssert.IsNotNull(_playerController, "[SwordHitNotifier] playerContorollerが未設定です");
            UAssert.IsNotNull(_stateHolder, "[SwordHitNotifier] stateHolderが未設定です");
        }

        void Start()
        {
            _animationFacade = ServiceLocator.Resolve<AnimParamFacadeBase>();
            UAssert.IsNotNull(_animationFacade, "[SwordHitNotifier] ServiceLocatorにanimationFacadeBaseが登録されていません");
        }

        public void OnSwordHit(Collider other)    //  頭にアタッチしたClassから呼び出される
        {
            if (!other.CompareTag("Sword")) return;

            if (!_stateHolder.IsCatchSword)
            {
                _playerController.EraseHitBox();
                _stateHolder.IsHitSwing = true;
                EffectActAPI.Action(new EffectActKey(EffectActor.Player, EffectActTrigger.Hit, EffectActType.Blow));
                _animationFacade.SwingerParam.IsHited.SetBool(true);
            }
        }
    }
}