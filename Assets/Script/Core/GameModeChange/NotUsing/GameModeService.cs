using UnityEngine;
using Kamatte.Core;

public sealed class GameModeService : IGameModeService
{
    private readonly GameModeStateMachine _stateMachine;

    //    --  Public API
    
    public GameMode Current => _stateMachine.Current;

    public GameModeService(GameModeStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void RequestChange(GameMode next)    //  ゲームモードの変更を要請する
    {
        if (!_stateMachine.CanTransition(next))
        {
            Debug.LogWarning($"Cannot change mode: {_stateMachine.Current} -> {next}");
            return;
        }

        _stateMachine.Transition(next);
    }
}