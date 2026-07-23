using SwordCatch.Core;
using UnityEngine;

namespace SwordCatch.Player
{
    //  InputSystemを初期化するクラス
    public sealed class InputSystemBootstrap : MonoBehaviour
    {
        InputSystem_Actions inputAction_System;

        // ゲーム状態を保持しているクラス
        [SerializeField] StateHolder stateHolder;

        HandleInputAction handleAction_Player;
        // プレイヤーの入力に対応するアクション定義クラス
        PlayerInputAction playerAction;

        void Awake()
        {
            inputAction_System = new InputSystem_Actions();

            playerAction = new PlayerInputAction(stateHolder);
            handleAction_Player = new HandleInputAction(inputAction_System, playerAction);
        }

        void OnDestroy()
        {
            handleAction_Player.SetOffReaction();
        }
    }
}