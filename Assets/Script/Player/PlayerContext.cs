using UnityEngine;
using Kamatte.SwordCatch;

namespace Kamatte.Player
{
    public class PlayerContext    //  初期化用コンテキスト
    {
        public PlayerHitBox HitBoxMgr { get; private set; }
        public Transform HeadTF { get; private set; }
        public StateHolder StateHolder { get; private set; }

        public AudioClip CatchSE{ get; private set; }

        public PlayerContext(PlayerHitBox hitBoxMgr, Transform headTF, StateHolder stateHolder, AudioClip catchSE)
        {
            HitBoxMgr = hitBoxMgr;
            HeadTF = headTF;
            StateHolder = stateHolder;
            CatchSE = catchSE;
        }
    }
}