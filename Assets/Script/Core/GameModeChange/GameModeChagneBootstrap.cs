using UnityEngine;

namespace Kamatte.Core
{
    public class ModeChagneBootstrap : MonoBehaviour    //  ゲームモード変更クラス系のBootstrap
    {
        ModeChangeList modeChangeList;    //  モード変更時の処理を格納するListを持っているクラス
        
        GameModeAPIFacade gameModeAPIFacade;    //  SLに登録して下位クラスから呼び出されるFacade

        PushModeChangeTask pushTask;    //  modeChangeListに処理を詰めるクラス

        ExecuteModeChangeTask executeTask;    //  ModeChagneListの処理を実行するクラス

        RemoveModeChangeTask removeModeChangeTask;    //  ModeChagneListの処理を解放するクラス

        private void Awake()
        {
            modeChangeList = new ModeChangeList();

            pushTask = new PushModeChangeTask(modeChangeList) as PushModeChangeTask;

            executeTask = new ExecuteModeChangeTask(modeChangeList);

            removeModeChangeTask = new RemoveModeChangeTask(modeChangeList);

            gameModeAPIFacade = new GameModeAPIFacade(pushTask, executeTask, removeModeChangeTask);
            ServiceLocator.Register<GameModeAPIFacade>(gameModeAPIFacade);
        }

        private void Start()
        {
        }
    }
}