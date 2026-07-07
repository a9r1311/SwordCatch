using Kamatte.Player;
using Kamatte.SwordCatch;
using UnityEngine;

namespace Kamatte.Core
{
    public class InputSystemBootstrap_SwordCatch : MonoBehaviour    //  白刃取りのInputSystemを初期化するクラス
    {
        InputSystem_Actions inputAction_System;

        [SerializeField] StateHolder stateHolder;    //  ミニゲームのStateを集約してる、Reader層から呼ばれる。

        HandleInputAction_SwordCatch handleAction_Player;
        PlayerInputAction_SwordCatch playerAction_SwordCatch;    //  プレイヤーのアクション関数を持つクラス

        void Awake()
        {
            inputAction_System = new InputSystem_Actions();

            playerAction_SwordCatch = new PlayerInputAction_SwordCatch(stateHolder);
            handleAction_Player = new HandleInputAction_SwordCatch(inputAction_System, playerAction_SwordCatch);
        }

        private void OnDestroy()
        {
            handleAction_Player.SetOffReaction();
        }
    }
}