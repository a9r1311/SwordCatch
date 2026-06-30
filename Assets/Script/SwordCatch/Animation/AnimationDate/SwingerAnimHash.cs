using System.Collections.Generic;
using UnityEngine;

namespace Kamatte.SwordCatch
{
    public class SwordSwingerAnimHash
    {
        private static readonly Dictionary<SwordCatchAnimID_Swinger, int> boolHashes = new()
    {
        { SwordCatchAnimID_Swinger.Idle,       Animator.StringToHash("IsTakingStance") },
        { SwordCatchAnimID_Swinger.SwingSword, Animator.StringToHash("IsSwingTime") },
        { SwordCatchAnimID_Swinger.SwingFast, Animator.StringToHash("IsSwingFast") },
        { SwordCatchAnimID_Swinger.SwingDelay, Animator.StringToHash("IsSwingDelay") },
        { SwordCatchAnimID_Swinger.Sheath, Animator.StringToHash("IsHited") },
    };

        public static int GetAnimation(SwordCatchAnimID_Swinger animID) => boolHashes[animID];
    }
}