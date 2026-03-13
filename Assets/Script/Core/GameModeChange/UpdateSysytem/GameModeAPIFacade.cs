namespace Kamatte.Core
{
    public class GameModeAPIFacade : GameModeAPIFacadeBase    //  SLを通して下位クラスからゲームモードAPIを使うためにアクセスされる
    {
        public GameModeAPIFacade(PushModeChangeTaskBase pushTask, ExecuteModeChangeTask executeTask, RemoveModeChangeTask removeTask) : base(pushTask, executeTask, removeTask)
        { }
    }
}