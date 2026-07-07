using UnityEngine;
using Kamatte.Core;
using Kamatte.SwordCatch;

namespace Kamatte.Player
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(PlayerController))]
    //  プレイヤー初期化クラス
    public sealed class PlayerBootstrap : MonoBehaviour
    {
        [SerializeField] PlayerController playerController; 
        PlayerContext context;    //  初期化のためのコンテキスト

        [SerializeField] PlayerHitBoxData playerHitBoxData;
        [SerializeField] Transform playerHeadTF;
        PlayerHitBox  playerHitBox;

        [SerializeField] Vector3 catchEffectPos;

        [SerializeField] StateHolder stateHolder;    //  ミニゲームのStateを集約してる、Reader層から呼ばれる。

        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip catchClip;

        //  --  Unity life cycle

        void Awake()
        {
            if (playerController == null)
            {
                playerController = GetComponent<PlayerController>();
                Debug.LogWarning("playerController isn't assigned in the Inspector");
            }
            if(playerHitBoxData == null)
            {
                Debug.LogError("playerHitBoxData isn't assigned in the Inspector");
            }
            if (playerHeadTF == null)
            {
                Debug.LogError("playerHeadTF isn't assigned in the Inspector");
            }
            if(stateHolder == null)
            {
                Debug.LogError("stateHolder isn't assigned in the Inspector");
            }


            playerHitBox = new PlayerHitBox(playerHitBoxData, playerController, playerHeadTF, catchEffectPos, stateHolder);

            context = new PlayerContext(playerHitBox, playerHeadTF, stateHolder, catchClip);
          
            playerController.Initialize(context);    //  Controllerの性質上Awakeで初期化
        }
    }
}