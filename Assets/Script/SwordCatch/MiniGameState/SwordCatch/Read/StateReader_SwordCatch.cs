namespace Kamatte.SwordCatch
{
    public class StateReader    //  判断層を通って、状態を持つクラスにアクセスする関数を持つ
    {
        StateHolder stateHolder;    //  SwordCatchの状態データを集約してるクラス、このクラスから読む

        public StateReader(StateHolder holder)    //  StateHolderBootstrap_SwordCatchから呼ばれる
        {
            stateHolder = holder;
        }

        public SwordCatchStateBase AcceseState()    //  ソードキャッチゲームの状態にアクセスする
        {
                return stateHolder.SwordCatchState;
        }
    }
}