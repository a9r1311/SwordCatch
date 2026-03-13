using UnityEngine;
using Kamatte.Core;
using Kamatte.Player;

namespace Kamatte.SwordCatch
{
    public class SwordHitNotifier : MonoBehaviour    //  “‚ª“–‚½‚Á‚½‚Éˆ—‚ğ“®‚©‚·
    {
        [SerializeField] PlayerHitBoxController _playerController;
        [SerializeField] StateHolder_SwordCatch stateHolder;

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Sword") && !stateHolder.SwordCatchState.CatchState.IsCatchSword)
            {
                _playerController.EraseHitBox();
                stateHolder.SwordCatchState.HitSwingState.ChagneHitSwordState(true);
                EffectActAPI.Action(new EffectActKey(EffectActor.Player, EffectActTrigger.Hit, EffectActType.Blow));
                ServiceLocator.Resolve<AnimParamFacadeBase>().SwingerParam.IsHited.SetBool(true);
            }
        }
    }
}