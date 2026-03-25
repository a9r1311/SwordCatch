using System.Collections;

namespace Kamatte.Core
{
    public interface IGameModeChangeStep    //  ゲームモード変更の際に動かす関数を持ってるクラスに継承
    {
        int Order { get; }    //  実行順(小さい方が先)
        IEnumerator Execute(GameMode prev, GameMode next);    //  処理関数をラップする関数
    }
}