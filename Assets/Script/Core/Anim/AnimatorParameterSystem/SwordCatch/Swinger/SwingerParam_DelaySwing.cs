using UnityEngine;
using Kamatte.Core;

namespace Kamatte.SwordCatch
{
    public class SwingerParam_DelaySwing : AnimParamBase    //  DelayêUÇËâ∫ÇÎÇµÇÃTrirgger
    {
        public SwingerParam_DelaySwing(Animator animator, string paramName) : base(animator, paramName) { }

        public void SetTrigger()
        {
            animator.SetTrigger(hash);
        }
    }
}