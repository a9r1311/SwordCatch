using Kamatte.Core;

public interface IGameModeService    //  ゲームモード系機能の提供をするClassのInterface
{
    GameMode Current { get; }    //  現在のゲームモード提供
    void RequestChange(GameMode next);    //  変更を要請する
}