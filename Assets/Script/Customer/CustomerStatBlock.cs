using UnityEngine;

namespace Kamatte.SwordCatch
{
    [System.Serializable]
    public sealed class SwingerStatBlock    //  ‚¨‹q‚³‚ñ‚ÌƒXƒe[ƒ^ƒX€–Ú
    {
        [Header("”’næ‚è‚Ì‚Ì«Ši")]
        public SwingPersonal swingerPersonal;    //  U‚è‰º‚ë‚µ‚Ì«Ši
        [Header("U‚è‰º‚ë‚·‚Ü‚Å‚ÌŠÔ")]
        public float swingTimer;    //  U‚è‰º‚ë‚·‚Ü‚Å‚ÌŠÔ
    }
}