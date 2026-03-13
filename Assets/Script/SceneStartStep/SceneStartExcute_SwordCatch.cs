using Kamatte.Core;

namespace Kamatte.SwordCatch
{
    public class SceneStartStepExcute : SceneStartStepExcuteBase
    {
        public override void StartSteps()
        {
            ServiceLocator.Resolve<IScreenFadeFacade>().FadeIn(1f);
        }
    }
}