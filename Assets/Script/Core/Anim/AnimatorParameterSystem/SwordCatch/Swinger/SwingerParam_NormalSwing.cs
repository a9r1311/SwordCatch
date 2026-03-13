using UnityEngine;
using Kamatte.Core;

namespace Kamatte.SwordCatch
{
    public class SwingerParam_NormalSwing : AnimParamBase    //  •’Ê‚ÌU‚è‰º‚ë‚µTrigger
    {
        public SwingerParam_NormalSwing(Animator animator, string paramName) : base(animator, paramName) { }

        public void SetTrigger()
        {
            animator.SetTrigger(hash);
        }
    }
}