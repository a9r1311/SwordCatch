using System.Collections.Generic;
using UnityEngine;

namespace SwordCatch.Animation
{
    public class SwordCatchAnimHash_Player    //  プレイヤーの白刃取りアニメーションハッシュ
    {
        private static readonly Dictionary<SwordCatchAnimID_Player, int> boolHashes = new()
    {
        { SwordCatchAnimID_Player.Idle,       Animator.StringToHash("IsTakingStan0ce") },
        { SwordCatchAnimID_Player.CatchSword, Animator.StringToHash("IsTryCatch") },
    };

        public static int GetAnimation(SwordCatchAnimID_Player animID) => boolHashes[animID];
    }
}
