using SwordCatch.Core;
using UnityEngine;

namespace SwordCatch.Player
{
    //  プレイヤー初期化クラス
    [DisallowMultipleComponent]
    [RequireComponent(typeof(PlayerController))]
    public sealed class PlayerBootstrap : MonoBehaviour
    {
        [SerializeField] PlayerController _playerController;  // プレイヤーコントローラー 
        PlayerContext _context;  // コンストラクタ引数短縮用クラス

        PlayerHitBox _playerHitBox;  // プレイヤー当たり判定クラス
        [SerializeField] PlayerHitBoxData _playerHitBoxData;  // 当たり判定データSO
        [SerializeField] Transform _playerHeadTF;  // 当たり判定用の頭Transform

        [SerializeField] StateHolder _stateHolder;  // ゲーム状況保持クラス
        
        [SerializeField] AudioClip _catchClip;  // キャッチSE

        void Awake()
        {
            if (_playerController == null)
            {
                _playerController = GetComponent<PlayerController>();
                Debug.LogWarning("playerController isn't assigned in the Inspector");
            }
            if(_playerHitBoxData == null)
            {
                Debug.LogError("playerHitBoxData isn't assigned in the Inspector");
            }
            if (_playerHeadTF == null)
            {
                Debug.LogError("playerHeadTF isn't assigned in the Inspector");
            }
            if(_stateHolder == null)
            {
                Debug.LogError("stateHolder isn't assigned in the Inspector");
            }
            if (_catchClip == null)
            {
                Debug.LogError("catchClip isn't assigned in the Inspector");
            }

            _playerHitBox = new PlayerHitBox(_playerHitBoxData, _playerController, _playerHeadTF, _stateHolder);

            _context = new PlayerContext(_playerHitBox, _playerHeadTF, _stateHolder, _catchClip);
          
            _playerController.Initialize(_context);    //  Controllerの性質上Awakeで初期化
        }
    }
}