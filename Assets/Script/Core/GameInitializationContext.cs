using UnityEngine;
using Kamatte.Player;

namespace Kamatte.Core
{
    public class GameInitializationContext : MonoBehaviour    //  全体的な初期化管理者
    {
        [SerializeField] PlayerHitBoxController _playerController;    //  プレイヤーコントローラー
        [SerializeField] PlayerHitBoxData playerHitBoxData;     //  プレイヤーヒットボックス群
        [SerializeField] Transform PlayerHeadTF;                //  プレイヤーヘッドTF

        void Awake()
        {
            //_playerController.Initialize(playerHitBoxData, PlayerHeadTF);    //  コントローラー初期化
        }
    }
}