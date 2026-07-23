using SwordCatch.Core;
using SwordCatch.Effect;
using UnityEngine;
using UAssert = UnityEngine.Assertions.Assert;

namespace SwordCatch.Player
{
    //  プレイヤー初期化クラス
    [DisallowMultipleComponent]
    [RequireComponent(typeof(PlayerController))]
    public sealed class PlayerBootstrap : MonoBehaviour
    {
        [SerializeField] PlayerController _playerController;  // プレイヤーコントローラー 
        PlayerContext _context;  // 初期化引数短縮用クラス

        [SerializeField] StateHolder _stateHolder;  // ゲーム状況保持クラス

        PlayerHitBox _playerHitBox;  // プレイヤー当たり判定管理クラス
        [SerializeField] PlayerHitBoxData _playerHitBoxData;  // プレイヤー当たり判定データ
        [SerializeField] Transform _playerHeadTF;  // 当たり判定用のTransform

        [SerializeField] StageEffectGenerater _stageEffectGenerater;  // ステージエフェクト生成クラス

        [SerializeField] AudioClip _catchSE;  // キャッチSE

        void Awake()
        {
            UAssert.IsNotNull(_playerController, "PlayerContorllerがインスペクターに設定されていません");
            UAssert.IsNotNull(_stateHolder, "StateHolderがインスペクターに設定されていません");
            UAssert.IsNotNull(_playerHitBoxData, "PlayerHitBoxDataがインスペクターに設定されていません");
            UAssert.IsNotNull(_playerHeadTF, "PlayerHeadTransFormがインスペクターに設定されていません");
            UAssert.IsNotNull(_stageEffectGenerater, "StageEffectGeneraterがインスペクターに設定されていません");
            UAssert.IsNotNull(_catchSE, "CatchSEがインスペクターに設定されていません");

            _playerHitBox = new PlayerHitBox(
                _playerHitBoxData,
                _playerController,
                _playerHeadTF,
                _stateHolder
                );

            _context = new PlayerContext(
                _stateHolder,
                _playerHitBox,
                _playerHeadTF,
                _stageEffectGenerater,
                _catchSE
                );
          
            _playerController.Initialize(_context);
        }
    }
}