using UnityEngine;

namespace Kamatte.SwordCatch
{
    public class StateReader_SwordCatch    //  判断層を通って、状態を持つクラスにアクセスする関数を持つ
    {
        StateHolder_SwordCatch stateHolder;    //  SwordCatchの状態データを集約してるクラス、このクラスから読む
        StateReadJudge_SwordCatch accessJudge;    //  まだ判断条件書ける環境じゃないから素通りさせてるけど、後から条件を追記したい

        public StateReader_SwordCatch(StateHolder_SwordCatch holder, StateReadJudge_SwordCatch judge)    //  StateHolderBootstrap_SwordCatchから呼ばれる
        {
            stateHolder = holder;
            accessJudge = judge;
        }

        public SwordCatchStateBase AcceseState()    //  ソードキャッチゲームの状態にアクセスする
        {
            if(accessJudge.IsVaildAccess())
            {
                return stateHolder.SwordCatchState;
            }
            else
            {
                Debug.LogWarning("適正でないアクセス検知");
                return null;
            }
        }
    }
}