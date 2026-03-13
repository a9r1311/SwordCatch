using UnityEngine;
using Kamatte.Core;

namespace Kamatte.SwordCatch
{
    public sealed class AnimParam_Swinger : AnimParamCollectionBase    //  各パラメーターを集約しているクラス
    {
        public SwingerParam_NormalSwing  NormalSwing{ get; }
        public SwingerParam_FastSwing  FastSwing{ get; }
        public SwingerParam_DelaySwing  DelaySwing{ get; }
        public SwingerParam_IsHited IsHited{ get; }
        public SwingerParam_IsCatch IsCatch{ get; }
        public AnimParam_Swinger
            (Animator animator, AnimParamRead animParamRead, AnimParamSet animParamSet, SwingerAnimParamContext ctx) :
            base(animator, animParamRead, animParamSet)
        {
            NormalSwing = ctx.NormalSwing;
            FastSwing = ctx.FastSwing;
            DelaySwing = ctx.DelaySwing;
            IsHited = ctx.IsHited;
            IsCatch = ctx.IsCatch;
        }
    }
}