namespace Kamatte.Core
{
    public class ExecuteModeChangeTask    //  TaskÇé¿çsÇ∑ÇÈ
    {
        ModeChangeList modeChangeList;

        public ExecuteModeChangeTask(ModeChangeList modeChangeList)
        {
            this.modeChangeList = modeChangeList;
        }

        public void Execute(GameMode prev, GameMode next)    //  é¿çs
        {
            ServiceLocator.Get<CoroutineRunner>().StartCoroutine(modeChangeList.Execute(prev, next));
        }
        public void startScene()
        {

        }
    }
}