//namespace Kamatte.SwordCatch
//{
//    public class StateWriter    //  判断層を通って、状態を持つクラスにアクセスする関数を持つ
//    {
//        StateHolder stateHolder;    //  SwordCatchの状態データを集約してるクラス、このクラスに書く

//        public StateWriter(StateHolder holder)    //  StateHolderBootstrap_SwordCatchから呼ばれる
//        {
//            stateHolder = holder;
//        }

//        //  CatchClassの白刃取り成功回数をインクリメントする
//        public void AddCatchSuccessCnt()
//        {
//            //  白刃取り成功
//            stateHolder.CatchSuccess();
//        }

//        //  ソードキャッチゲームの状態に書き込む
//        public void ChangeCatchState(bool isCatchSwing)
//        {
//                stateHolder.IsCatchSword = isCatchSwing;
//        }
//        //  ソードキャッチゲームの状態に書き込む
//        public void ChangeHitSwingState(bool isHitSwing)
//        {
//                stateHolder.IsHitSwing = isHitSwing;
//        }
//    }
//}