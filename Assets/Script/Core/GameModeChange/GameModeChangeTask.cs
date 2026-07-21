using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SwordCatch.Core
{
    //  ゲームモード変更時の処理を管理するクラス
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(-10)]
    public sealed class GameModeChangeTask : MonoBehaviour
    {
        readonly List<IGameModeChangeTask> steps = new List<IGameModeChangeTask>();

        void Awake()
        {
            ServiceLocator.Register<GameModeChangeTask>(this);
            DontDestroyOnLoad(this);
        }

        //  処理リストに詰める
        public void PushStep(IGameModeChangeTask step)
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

        //  処理実行
        public IEnumerator Execute(GameMode prev, GameMode next)
        {
            MyLogger.Log("ゲームモード変更処理開始");
            foreach (IGameModeChangeTask task in steps.OrderBy(s => s.Order))
            {
                yield return task.Execute(prev, next);
            }
        }

        //  処理リストから処理を除去
        public void RemoveStep(IGameModeChangeTask task)
        {
            steps.Remove(task);
        }
    }
}