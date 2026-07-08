using UnityEngine;
using Kamatte.Core;

namespace Kamatte.SwordCatch
{
    //  Playerのアニメーションパラーメータを保持しているクラス
    public sealed class AnimParam_Player : AnimParamCollectionBase
    {
        int _hash;
        
        public AnimParam_Player(Animator animator,string paramName)
            : base(animator) 
        {
            _hash = Animator.StringToHash(paramName);
        }

        //  キャッチアニメーション発火
        public void Catch()
        {
            animator.SetTrigger(_hash);
        }
    }
}