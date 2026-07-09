using UnityEngine;
namespace Kamatte.SwordCatch
{
    //  スウィンガーの能力値クラス
    [System.Serializable]
    public sealed class SwingerStatBlock
    {
        [Header("白刃取りの時の性格")]
        public SwingPersonal SwingerPersonal;
        [Header("振り下ろすまでの時間")]
        public float SwingTimer;
        [Header("叫んでから高速降り下ろしまでの時間")]
        public float ScreemToSwing;
    }
}