using UnityEngine;

namespace Kamatte.Core
{
    public static class GameModeAPI    //  ゲームモードに関するAPI
    {

        //  --  Public API

        public static GameMode Current => ServiceLocator.Resolve<IGameModeService>().Current;

        public static void EnterMode(GameMode next)    //  指定ゲームモードに入る
        {
            ServiceLocator.Resolve<IGameModeService>().RequestChange(next);
        }
    }
}