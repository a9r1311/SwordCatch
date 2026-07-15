using UnityEngine;

namespace Kamatte.Core
{
    //  パラメータ集約クラスBase
    public abstract class AnimParamCollectionBase
    {
        protected Animator animator;

        protected AnimParamCollectionBase(Animator animator)
        {
            this.animator = animator;
        }
    }
}