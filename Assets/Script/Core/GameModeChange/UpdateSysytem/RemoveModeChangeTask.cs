namespace Kamatte.Core
{
    public class RemoveModeChangeTask    //  スタックリストから要素を解放するクラス
    {
        ModeChangeList modeChangeList;
        IJudgeAcceptableRemove judgeAcceptableRemove;

        public RemoveModeChangeTask(ModeChangeList modeChangeList, IJudgeAcceptableRemove judge)
        {
            this.modeChangeList = modeChangeList;
            judgeAcceptableRemove = judge;
        }

        public void RemoveStep(IGameModeChangeStep step)    //  スタックリストからモード変更時の処理を解放
        {
            if (judgeAcceptableRemove.Judge())
            {
                modeChangeList.RemoveStep(step);
            }
        }
    }
}