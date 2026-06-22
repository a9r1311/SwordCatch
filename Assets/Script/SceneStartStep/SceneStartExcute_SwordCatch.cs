using Kamatte.Core;
using System.Threading.Tasks;

namespace Kamatte.SwordCatch
{
    public sealed class SceneStartStepExcute : SceneStartStepExcuteBase
    {
        public override ValueTask StartSteps()    //  ”’næ‚èŠJn‚Ìˆ—
        {
            ServiceLocator.Resolve<IScreenFadeFacade>().FadeIn(1f);
            return default;
        }
    }
}