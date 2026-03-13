namespace Kamatte.Core
{
    public class PushModeChangeTask : PushModeChangeTaskBase    //  下位クラスからSLを通してアクセスされるモード変更時の処理をStackListに詰めるクラス
    {
        
        //  --  Public API

        public PushModeChangeTask(ModeChangeList list, IJudgeAcceptablePush judge) : base(list, judge)   //  Bootstrapで呼ばれる
        { }

        public override void PushStep(IGameModeChangeStep step)    //  スタックリストにStepを追加
        {
            base.PushStep(step); 
        }
    }
}