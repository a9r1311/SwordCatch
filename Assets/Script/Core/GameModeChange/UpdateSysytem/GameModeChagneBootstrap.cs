using UnityEngine;

namespace Kamatte.Core
{
    public class ModeChagneBootstrap : MonoBehaviour    //  ゲームモード変更クラス系のBootstrap
    {
        ModeChangeList modeChangeList;    //  モード変更時の処理を格納するListを持っているクラス
        
        GameModeAPIFacadeBase gameModeAPIFacade;    //  SLに登録して下位クラスから呼び出されるFacade

        PushModeChangeTaskBase pushTask;    //  modeChangeListに処理を詰めるクラス
        IJudgeAcceptablePush judgePush;    //  処理詰めが適正な状態で行われているかを確認するクラス

        ExecuteModeChangeTask executeTask;    //  ModeChagneListの処理を実行するクラス
        IJudgeAcceptableExecute judgeAcceptableExecute;    //  処理実行が適正な状態で行われているか判断するクラス

        RemoveModeChangeTask removeModeChangeTask;    //  ModeChagneListの処理を解放するクラス
        IJudgeAcceptableRemove judgeAcceptableRemove;    //  処理解放が適切な状態で行われているか判断するクラス

        private void Awake()
        {
            modeChangeList = new ModeChangeList();

            judgePush = new JudgeAcceotablePush();
            pushTask = new PushModeChangeTask(modeChangeList , judgePush) as PushModeChangeTaskBase;

            judgeAcceptableExecute = new JudgeAcceptableExecute();
            executeTask = new ExecuteModeChangeTask(modeChangeList, judgeAcceptableExecute);

            judgeAcceptableRemove = new JudgeAcceptableRemove();
            removeModeChangeTask = new RemoveModeChangeTask(modeChangeList, judgeAcceptableRemove);

            gameModeAPIFacade = new GameModeAPIFacade(pushTask, executeTask, removeModeChangeTask) as GameModeAPIFacadeBase;
            ServiceLocator.Register<GameModeAPIFacadeBase>(gameModeAPIFacade);
        }

        private void Start()
        {
        }
    }
}