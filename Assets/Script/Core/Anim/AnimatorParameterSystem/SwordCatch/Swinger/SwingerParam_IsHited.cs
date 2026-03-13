using UnityEngine;
using Kamatte.Core;

namespace Kamatte.SwordCatch
{
    public class SwingerParam_IsHited : AnimParamBase    //  ìÅÇ™ìñÇΩÇ¡ÇΩÇ©ÇÃFlag
    {
        public SwingerParam_IsHited(Animator animator, string paramName) : base(animator, paramName) { }

        public void SetBool(bool isHited)
        {
            animator.SetBool(hash, isHited);
        }
    }
}