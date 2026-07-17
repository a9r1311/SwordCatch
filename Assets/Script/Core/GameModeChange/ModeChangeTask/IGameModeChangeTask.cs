using System.Collections;

namespace Kamatte.Core
{
    //  ゲームモード変更時のタスクインターフェース
    public interface IGameModeChangeTask
    {
        int Order { get; }    //  実行順(小さい方が先)
        IEnumerator Execute(GameMode prev, GameMode next);
    }
}