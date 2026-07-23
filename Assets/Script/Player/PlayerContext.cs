using SwordCatch.Core;
using SwordCatch.Effect;
using UnityEngine;

namespace SwordCatch.Player
{
    //  引数短縮用
    public sealed class PlayerContext
    {
        //  ゲーム状態保持クラス
        public StateHolder StateHolder { get; private set; }
        //  プレイヤー当たり判定管理クラス
        public PlayerHitBox HitBoxMgr { get; private set; }
        //  当たり判定生成の際に使用するTF
        public Transform HeadTF { get; private set; }
        //  ステージエフェクト生成クラス
        public StageEffectGenerater StageEffectGenerater { get; private set; }
        //  キャッチ時のサウンドエフェクト
        public AudioClip CatchSE{ get; private set; }

        public PlayerContext(
            StateHolder stateHolder,
            PlayerHitBox hitBoxMgr,
            Transform headTF,
            StageEffectGenerater stageEffect,
            AudioClip catchSE
            )
        {
            StateHolder = stateHolder;
            HitBoxMgr = hitBoxMgr;
            HeadTF = headTF;
            StageEffectGenerater = stageEffect;
            CatchSE = catchSE;
        }
    }
}