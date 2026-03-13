using UnityEngine;
using Kamatte.SwordCatch;

namespace Kamatte.Player
{
    public class PlayerContext    //  初期化用コンテキスト
    {
        public PlayerHitBoxMgr HitBoxMgr { get; private set; }
        public Transform HeadTF { get; private set; }
        public StateReader_SwordCatch StateReader { get; private set; }
        public StateWriter_SwordCatch StateWriter { get; private set; }
        public AudioSource AudioSource{ get; private set; }
        public AudioClip CatchSE{ get; private set; }

        public PlayerContext(PlayerHitBoxMgr hitBoxMgr, Transform headTF, StateReader_SwordCatch stateReader, StateWriter_SwordCatch stateWriter, AudioSource audioSource, AudioClip catchSE)
        {
            HitBoxMgr = hitBoxMgr;
            HeadTF = headTF;
            StateReader = stateReader;
            StateWriter = stateWriter;
            AudioSource = audioSource;
            CatchSE = catchSE;
        }
    }
}