using System.Threading.Tasks;
using UnityEngine;

namespace Kamatte.Core
{
    public interface IScreenFadeFacade
    {
        public Task FadeIn(float duration);

        public Task FadeOut(float Duration, Color? fadeColor = null);
    }
}