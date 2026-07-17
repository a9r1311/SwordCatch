namespace Kamatte.Core
{
    public class RemoveModeChangeTask    //  スタックリストから要素を解放するクラス
    {
        ModeChangeList modeChangeList;

        public RemoveModeChangeTask(ModeChangeList modeChangeList)
        {
            this.modeChangeList = modeChangeList;
        }

        public void RemoveStep(IGameModeChangeStep step)    //  スタックリストからモード変更時の処理を解放
        {
            modeChangeList.RemoveStep(step);
        }
    }
}