using UnityEngine;
using Kamatte.SwordCatch;

namespace Kamatte.Player
{
    public class PlayerContext    //  初期化用コンテキスト
    {
        public PlayerHitBox HitBoxMgr { get; private set; }
        public Transform HeadTF { get; private set; }
        public StateReader StateReader { get; private set; }
        public StateWriter StateWriter { get; private set; }
        public AudioClip CatchSE{ get; private set; }

        public PlayerContext(PlayerHitBox hitBoxMgr, Transform headTF, StateReader stateReader, StateWriter stateWriter, AudioClip catchSE)
        {
            HitBoxMgr = hitBoxMgr;
            HeadTF = headTF;
            StateReader = stateReader;
            StateWriter = stateWriter;
            CatchSE = catchSE;
        }
    }
}