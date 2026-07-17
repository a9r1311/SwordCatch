namespace Kamatte.Core
{
    //  GameMode変更機能の窓口
    public class GameModeAPIFacade
    {
        //  StackListにStepをPushするクラス
        public PushModeChangeTask pushTask;
        //  StackListのStepを実行するクラス
        public ExecuteModeChangeTask executeTask;
        //  StaclListのStepを解放するクラス
        public RemoveModeChangeTask removeTask;

        public GameModeAPIFacade(
            PushModeChangeTask pushTask,
            ExecuteModeChangeTask executeTask,
            RemoveModeChangeTask removeTask
            )
        {
            this.pushTask = pushTask;
            this.executeTask = executeTask;
            this.removeTask = removeTask;
        }
    }
}