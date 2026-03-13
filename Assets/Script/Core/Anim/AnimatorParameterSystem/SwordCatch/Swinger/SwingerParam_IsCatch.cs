using UnityEngine;
using Kamatte.Core;

namespace Kamatte.SwordCatch
{
    public class SwingerParam_IsCatch : AnimParamBase    //  刀がキャッチされたかのフラグ
    {
        public SwingerParam_IsCatch(Animator animator, string paramName) : base(animator, paramName) { }

        public void SetBool(bool isHited)
        {
            Debug.Log("888");
            animator.SetBool(hash, isHited);
        }
    }
}