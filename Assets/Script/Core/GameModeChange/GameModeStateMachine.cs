using System;
using System.Collections.Generic;
using Kamatte.Core;

public sealed class GameModeStateMachine    //  ゲームモード変更クラス
{
    private readonly Dictionary<GameMode, GameMode[]> _allowedTransitions;
    private readonly GameModeChanger _modeChanger;
    
    //  --  publicAPI

    public GameMode Current { get; private set; }

    public GameModeStateMachine(GameMode initial, GameModeChanger modeChanger)
    {
        Current = initial;

        _allowedTransitions = new()
        {
            { GameMode.Title,   new[]{ GameMode.SwordCatch } },
            { GameMode.SwordCatch,  new[]{ GameMode.SwordCatch } },
        };

        _modeChanger = modeChanger;
    }

    public bool CanTransition(GameMode next)    //  変更できるかを確認する
    {
        return _allowedTransitions.TryGetValue(Current, out var list)
               && Array.Exists(list, m => m == next);
    }

    public void Transition(GameMode next)    //  変更する
    {
        var prev = Current;
        _modeChanger.Chagne(Current, next);
        Current = next;
    }
}