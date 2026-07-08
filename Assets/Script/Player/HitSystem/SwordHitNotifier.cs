using UnityEngine;
using UAssert = UnityEngine.Assertions.Assert;
using Kamatte.Core;
using Kamatte.Player;

namespace Kamatte.SwordCatch
{
    //  “‚ª“–‚½‚Á‚½‚Ìˆ—‚ğ‚·‚éƒNƒ‰ƒX
    [DisallowMultipleComponent]
    public sealed class SwordHitNotifier : MonoBehaviour
    {
        [SerializeField] PlayerController _playerController;
        [SerializeField] StateHolder _stateHolder;

        AnimParamFacadeBase _animationFacade;

        void Awake()
        {
            UAssert.IsNotNull(_playerController, "[SwordHitNotifier] playerContoroller‚ª–¢İ’è‚Å‚·");
            UAssert.IsNotNull(_stateHolder, "[SwordHitNotifier] stateHolder‚ª–¢İ’è‚Å‚·");
        }

        void Start()
        {
            _animationFacade = ServiceLocator.Resolve<AnimParamFacadeBase>();
            UAssert.IsNotNull(_animationFacade, "[SwordHitNotifier] ServiceLocator‚ÉanimationFacadeBase‚ª“o˜^‚³‚ê‚Ä‚¢‚Ü‚¹‚ñ");
        }

        //  “‚ª“–‚½‚Á‚½‚Ìˆ—
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