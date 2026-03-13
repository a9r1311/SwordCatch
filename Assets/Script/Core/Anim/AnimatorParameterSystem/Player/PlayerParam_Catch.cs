using UnityEngine;
using Kamatte.Core;

namespace Kamatte.Player
{
    public class PlayerParam_Catch : AnimParamBase    //  プレイヤーのキャッチTrigger
    {
        public PlayerParam_Catch(Animator animator, string paramName) : base(animator, paramName) { }

        int CatchTrigger => hash;

        public void SetTrigger()
        {
            animator.SetTrigger(hash);
        }
    }
}