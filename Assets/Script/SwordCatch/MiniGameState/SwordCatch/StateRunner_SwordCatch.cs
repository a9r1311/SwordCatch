using UnityEngine;

namespace Kamatte.SwordCatch
{
    [RequireComponent(typeof(StateSystemBootstrap))]
    [DisallowMultipleComponent]
    public class StateHolder : MonoBehaviour
    {
        public SwordCatchStateBase SwordCatchState { get; private set; }

        public void Initialize(SwordCatchStateBase swordCatchState)    //  BootStrap‚©‚çŒÄ‚Î‚ê‚é‰Šú‰»
        {
            SwordCatchState = swordCatchState;
        }
    }
}