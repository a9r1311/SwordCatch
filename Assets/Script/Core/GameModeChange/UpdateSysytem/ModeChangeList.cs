using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Kamatte.Core
{
    public class ModeChangeList    //  モード変更時に動く処理を保存してるリスト、下位クラスからSLのFacadeを通してアクセスされる
    {
        private readonly List<IGameModeChangeStep> steps = new List<IGameModeChangeStep>();
        
        public void PushStep(IGameModeChangeStep step)    //  ステップリストに処理を詰める
        {
            if(!steps.Contains(step))
            {
                steps.Add(step);
            }
            else
            {
                return;
            }
        }

        public IEnumerator Execute(GameMode prev, GameMode next)    //  実行
        {
            foreach (IGameModeChangeStep step in steps.OrderBy(s => s.Order))
            {
                yield return step.Execute(prev, next);
            }
        }

        public void RemoveStep(IGameModeChangeStep step)    //  リストからstepを解放
        {
            steps.Remove(step);
        }
    }
}