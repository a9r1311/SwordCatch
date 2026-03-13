namespace Kamatte.Core
{
    public abstract class GameModeAPIFacadeBase    //  差し替えのための抽象化Base
    {
        public PushModeChangeTaskBase pushTask;    //  StackListにStepをPushするクラス
        public ExecuteModeChangeTask executeTask;    //  StackListのStepを実行するクラス
        public RemoveModeChangeTask removeTask;    //  StaclListのStepを解放するクラス

        public GameModeAPIFacadeBase(PushModeChangeTaskBase pushTask, ExecuteModeChangeTask executeTask, RemoveModeChangeTask removeTask)
        {
            this.pushTask = pushTask;
            this.executeTask = executeTask;
            this.removeTask = removeTask;
        }
    }
}