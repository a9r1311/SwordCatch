using UnityEngine;
using UAssert = UnityEngine.Assertions.Assert;
using Kamatte.Core;
using Kamatte.Player;

namespace Kamatte.SwordCatch
{
    [DisallowMultipleComponent]
    public sealed class SwordHitNotifier : MonoBehaviour    //  刀が当たった時に処理を動かす
    {
        [SerializeField] PlayerController playerController;
        [SerializeField] StateHolder_SwordCatch stateHolder;

        private AnimParamFacadeBase animationFacade;

        void Awake()
        {
            UAssert.IsNotNull(playerController, "[SwordHitNotifier] playerContorollerが未設定です");
            UAssert.IsNotNull(stateHolder, "[SwordHitNotifier] stateHolderが未設定です");
        }

        void Start()
        {
            animationFacade = ServiceLocator.Resolve<AnimParamFacadeBase>();
            UAssert.IsNotNull(animationFacade, "[SwordHitNotifier] ServiceLocatorにanimationFacadeBaseが登録されていません");
        }

        public void OnSwordHit(Collider other)    //  頭にアタッチしたClassから呼び出される
        {
            if (!other.CompareTag("Sword")) return;

            if (!stateHolder.SwordCatchState.CatchState.IsCatchSword)
            {
                playerController.EraseHitBox();
                stateHolder.SwordCatchState.HitSwingState.ChagneHitSwordState(true);
                EffectActAPI.Action(new EffectActKey(EffectActor.Player, EffectActTrigger.Hit, EffectActType.Blow));
                animationFacade.SwingerParam.IsHited.SetBool(true);
            }
        }
    }
}