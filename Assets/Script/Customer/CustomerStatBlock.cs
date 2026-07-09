using UnityEngine;

namespace Kamatte.SwordCatch
{
    //  スウィンガーの能力値クラス
    [System.Serializable]
    public sealed class SwingerStatBlock
    {
        [Header("白刃取りの時の性格")]
        public SwingPersonal SwingerPersonal;

        [Header("最初の振り下ろし方法")]
        public SwingType FirstSwingType = SwingType.Normal;
        [Header("最初に降り下ろすまでの時間")]
        public float FirstSwingTime = 10f;

        [Header("叫んでから高速降り下ろしまでの時間")]
        public float ScreemToSwing = 0.74f;
    }
}