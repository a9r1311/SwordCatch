namespace Kamatte.Core
{
    public sealed class GameModeChanger    //  ゲームモード変更クラス
    {
        public void Chagne(GameMode prev, GameMode next)    //  ゲームモード変更
        {
            GameModeChagneExecutor executor = new GameModeChagneExecutor();

            ServiceLocator.Resolve<ScreenFade>().FadeIn(1f);
            ServiceLocator.Resolve<CoroutineRunner>().StartCoroutine(executor.Execute(prev, next));
        }
    }
}