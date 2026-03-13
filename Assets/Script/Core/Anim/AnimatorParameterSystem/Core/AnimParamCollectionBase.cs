using UnityEngine;

namespace Kamatte.Core
{
    public abstract class AnimParamCollectionBase    //  パラメータ集約クラスの共通処理を吸い上げる抽象化Base
    {
        protected Animator animator;
        protected AnimParamRead paramRead;
        protected AnimParamSet paramSet;

        protected AnimParamCollectionBase(Animator animator, AnimParamRead paramRead, AnimParamSet paramSet)
        {
            this.animator = animator;
            this.paramRead = paramRead;
            this.paramSet = paramSet;
        }
       
    }
}