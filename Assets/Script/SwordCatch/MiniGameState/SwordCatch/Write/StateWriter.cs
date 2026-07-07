using UnityEngine;

namespace Kamatte.SwordCatch
{
    public class StateWriter    //  判断層を通って、状態を持つクラスにアクセスする関数を持つ
    {
        StateHolder stateHolder;    //  SwordCatchの状態データを集約してるクラス、このクラスに書く

        public StateWriter(StateHolder holder)    //  StateHolderBootstrap_SwordCatchから呼ばれる
        {
            stateHolder = holder;
        }

        public void AddCatchSuccessCnt()    //  CatchClassの白刃取り成功回数をインクリメントする
        {
            stateHolder.SwordCatchState.CatchState.AddSuccessCount();
        }

        public void ChangeCatchState(bool isCatchSwing)    //  ソードキャッチゲームの状態に書き込む
        {
                stateHolder.SwordCatchState.CatchState.ChagneCatchSwordState(isCatchSwing);
        }
        public void ChangeHitSwingState(bool isHitSwing)    //  ソードキャッチゲームの状態に書き込む
        {
                stateHolder.SwordCatchState.HitSwingState.ChagneHitSwordState(isHitSwing);
        }
    }
}