using System.Threading.Tasks;
using UnityEngine;

namespace Kamatte.Core
{
    public class ScreenFadeFacade : IScreenFadeFacade    //  BootstrapからServiceLocatorに登録されて、使われる窓口
    {
        ScreenFade screenFade;    //  フェード関数クラス

        public ScreenFadeFacade(ScreenFade screenFade)    //  Bootstrapから呼ばれる
        {
            this.screenFade = screenFade;
        }

        public Task FadeIn(float duration)
        {
                return screenFade.FadeIn(duration);
        }

        public Task FadeOut(float Duration, Color? fadeColor = null)
        {
                return screenFade.FadeOut(Duration);
        }
    }
}