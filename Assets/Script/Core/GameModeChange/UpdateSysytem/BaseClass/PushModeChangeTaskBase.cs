namespace Kamatte.Core
{
    public abstract class PushModeChangeTaskBase    //  プッシュ用のClassの共通処理吸い上げようClass
    {
        ModeChangeList modeChangeList;    //  StackのListがあるクラス、このクラスにある関数をつかってPushする
        IJudgeAcceptablePush judgeAcceotableStack;    //  Stackにプッシュしていいかを判定してくれる

        public PushModeChangeTaskBase(ModeChangeList list, IJudgeAcceptablePush judge)    //  Bootstrapで呼ばれる
        {
            modeChangeList = list;
            judgeAcceotableStack = judge;
        }

        public virtual void PushStep(IGameModeChangeStep step)    //  スタックリストにStepを追加
        {
            if (judgeAcceotableStack.Judge())
            {
                modeChangeList.PushStep(step);
            }
        }
    }
}