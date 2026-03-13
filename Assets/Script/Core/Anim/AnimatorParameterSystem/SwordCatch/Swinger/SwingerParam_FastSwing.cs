using UnityEngine;
using Kamatte.Core;

namespace Kamatte.SwordCatch
{
    public class SwingerParam_FastSwing : AnimParamBase    //  çÇë¨Ç≈êUÇËâ∫ÇÎÇ∑Trigger
    {
        public SwingerParam_FastSwing(Animator animator, string paramName) : base(animator, paramName) { }

        public void SetTrigger()
        {
            animator.SetTrigger(hash);
        }
    }
}