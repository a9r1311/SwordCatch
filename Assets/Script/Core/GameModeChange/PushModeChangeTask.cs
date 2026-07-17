namespace Kamatte.Core
{
    //  ゲームモード変更時の処理を追加するクラス
    public sealed class PushModeChangeTask
    {
        ModeChangeList modeChangeList;

        public PushModeChangeTask(ModeChangeList list)
        {
            modeChangeList = list;
        }

        //  GameMode変更時の処理を追加
        public void PushStep(IGameModeChangeStep step)
        {
            modeChangeList.PushStep(step);
        }
    }
}