using SwordCatch.Core;
using UnityEngine;

namespace SwordCatch.Player
{
    //  コンストラクタ引数短縮用クラス
    public class PlayerContext
    {
        public PlayerHitBox HitBoxMgr { get; private set; }
        public Transform HeadTF { get; private set; }
        public StateHolder StateHolder { get; private set; }

        public AudioClip CatchSE{ get; private set; }

        public PlayerContext(
            PlayerHitBox hitBoxMgr,
            Transform headTF,
            StateHolder stateHolder,
            AudioClip catchSE
            )
        {
            HitBoxMgr = hitBoxMgr;
            HeadTF = headTF;
            StateHolder = stateHolder;
            CatchSE = catchSE;
        }
    }
}