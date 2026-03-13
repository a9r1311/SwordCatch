using UnityEngine;

namespace Kamatte.SwordCatch
{
    public class StateWriter_SwordCatch    //  判断層を通って、状態を持つクラスにアクセスする関数を持つ
    {
        StateHolder_SwordCatch stateHolder;    //  SwordCatchの状態データを集約してるクラス、このクラスに書く
        StateWriteJudge_SwordCatch writeJudge;    //   //  まだ判断条件書ける環境じゃないから素通りさせてるけど、後から条件を追記したい

        public StateWriter_SwordCatch(StateHolder_SwordCatch holder, StateWriteJudge_SwordCatch judge)    //  StateHolderBootstrap_SwordCatchから呼ばれる
        {
            stateHolder = holder;
            writeJudge = judge;
        }

        public void AddCatchSuccessCnt()    //  CatchClassの白刃取り成功回数をインクリメントする
        {
            stateHolder.SwordCatchState.CatchState.AddSuccessCount();
        }

        public void ChangeCatchState(bool isCatchSwing)    //  ソードキャッチゲームの状態に書き込む
        {
            if (writeJudge.IsVaildAccess())
            {
                stateHolder.SwordCatchState.CatchState.ChagneCatchSwordState(isCatchSwing);
            }
            else
            {
                Debug.LogWarning("適正でないアクセス検知");
            }
        }
        public void ChangeHitSwingState(bool isHitSwing)    //  ソードキャッチゲームの状態に書き込む
        {
            if (writeJudge.IsVaildAccess())
            {
                stateHolder.SwordCatchState.HitSwingState.ChagneHitSwordState(isHitSwing);
            }
            else
            {
                Debug.LogWarning("適正でないアクセス検知");
            }
        }
    }
}