using System.Collections;
using UnityEngine;

namespace Kamatte.Core
{
    //  GameMode変更時のフェード処理
    public sealed class FadeOutStep : IGameModeChangeStep
    {
        int _order;  // 実行順(小さい方が先)

        public int Order => _order;

        public FadeOutStep(int order)
        {
            _order = order;
        }

        //  フェード処理
        public IEnumerator Execute(GameMode prev, GameMode next)
        {
            System.Threading.Tasks.Task task;
            
            task = ServiceLocator.Get<ScreenFade>().FadeOut(1f);
            yield return new WaitUntil(() => task.IsCompleted);
        }
    }
}