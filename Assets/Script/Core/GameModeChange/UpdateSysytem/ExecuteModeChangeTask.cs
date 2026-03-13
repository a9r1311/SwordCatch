using Unity.VisualScripting;

namespace Kamatte.Core
{
    public class ExecuteModeChangeTask    //  TaskÇé¿çsÇ∑ÇÈ
    {
        ModeChangeList modeChangeList;
        IJudgeAcceptableExecute judgeAcceptableExecute;

        public ExecuteModeChangeTask(ModeChangeList modeChangeList, IJudgeAcceptableExecute judge)
        {
            this.modeChangeList = modeChangeList;
            judgeAcceptableExecute = judge;
        }

        public void Execute(GameMode prev, GameMode next)    //  é¿çs
        {
            if (judgeAcceptableExecute.Judge())
            {
                ServiceLocator.Resolve<ICoroutineRunnerFacade>().StartCoroutine(modeChangeList.Execute(prev, next));
            }
        }
        public void startScene()
        {

        }
    }
}