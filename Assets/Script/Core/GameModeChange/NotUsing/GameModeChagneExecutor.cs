using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Kamatte.Core
{
    public sealed class GameModeChagneExecutor    //  ゲームモード変更時に動く関数を保持してるクラス
    {
        private readonly List<IGameModeChangeStep> _steps = new List<IGameModeChangeStep>();

        public void AddStep(IGameModeChangeStep step)    //  関数追加
        {
            _steps.Add(step);
        }

        public IEnumerator Execute(GameMode prev, GameMode next)    //  実行
        {
            foreach (IGameModeChangeStep step in _steps.OrderBy(s => s.Order))
            {
                yield return step.Execute(prev, next);
            }
        }
    }
}