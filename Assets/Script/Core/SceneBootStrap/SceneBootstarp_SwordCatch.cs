using UnityEngine;
using UnityEngine.UI;
using UAsset = UnityEngine.Assertions.Assert;
using TMPro;
using SwordCatch.Audio;
using SwordCatch.Result;
using SwordCatch.ScreenEffect;
using SwordCatch.Swinger;

namespace SwordCatch.Core
{
    //  シーンの初期化役
    [DisallowMultipleComponent]
    public sealed class SceneBootstrap_SwordCatch : MonoBehaviour
    {
        // 白刃取りの状況を保持しているクラス
        [SerializeField] StateHolder _stateHolder;

        // ゲームモード変更時のフェードTask
        FadeOutStep _fadeOutTask;

        // ゲームモード変更時のリザルト表示Task
        ResultDisplayTask _resultDisplayTask;
        [SerializeField] GameObject _resultRoot;
        [SerializeField] TextMeshProUGUI _playerPowerTxt;
        [SerializeField] TextMeshProUGUI _catchCountTxt;
        [SerializeField] Button _retryButton;

        //  Swingerの振り下ろしタイミングコントローラー
        [SerializeField] SwingerController _swingTimeController;
        Swing _swing;

        //  白刃取り成功回数と称号のペアデータ
        [SerializeField] PlayerLevelCatalog _levelCatalog;

        SceneMgr _sceneMgr;

        //  ゲームモード変更時の処理システム
        GameModeChangeTask _gameModeTask;
        
        readonly int _fadeOutOrder = 20;
        
        readonly int _lowerAuidoOrder = 25;
        LowerAudio _lowerAudio;
        [SerializeField] AudioSource _bgmSource;
        readonly float _loweredVolume = 0.02f;
        
        readonly int _resultDisplayOrder = 50;

        void Awake()
        {
            UAsset.IsNotNull(_stateHolder, "stateHolderがインスペクターに設定されていません");
            UAsset.IsNotNull(_resultRoot, "resultRootがインスペクターに設定されていません");
            UAsset.IsNotNull(_playerPowerTxt, "playerPowerTextがインスペクターに設定されていません");
            UAsset.IsNotNull(_catchCountTxt, "catchCountTextがインスペクターに設定されていません");
            UAsset.IsNotNull(_retryButton, "retryButtonがインスペクターに設定されていません");
            UAsset.IsNotNull(_swingTimeController, "swingTimeControllerがインスペクターに設定されていません");
            UAsset.IsNotNull(_bgmSource, "bgmSourceがインスペクターに設定されていません");
            UAsset.IsNotNull(_levelCatalog, "levelCatalogがインスペクターに設定されていません");
            
            _swing = new Swing();

            _fadeOutTask = new FadeOutStep(_fadeOutOrder);
            _lowerAudio = new LowerAudio(_lowerAuidoOrder, _bgmSource, _loweredVolume);
            _resultDisplayTask = new ResultDisplayTask(_resultDisplayOrder, _resultRoot, _catchCountTxt, _playerPowerTxt, _stateHolder, _levelCatalog);
        }

        void Start()
        {
            //  インゲーム開始時フェードイン
            ServiceLocator.Get<ScreenFade>().FadeIn(1f);
            _sceneMgr = ServiceLocator.Get<SceneMgr>();

            _swingTimeController.Initialize(_swing);
            
            _retryButton.onClick.AddListener(Retry);

            _gameModeTask = ServiceLocator.Get<GameModeChangeTask>();
            _gameModeTask.PushStep(_resultDisplayTask);
            _gameModeTask.PushStep(_lowerAudio);
            _gameModeTask.PushStep(_fadeOutTask);
        }

        void Retry()
        {
            _sceneMgr.LoadScene(GameMode.SwordCatch);
        }

        void OnDestroy()
        {
            _retryButton.onClick.RemoveAllListeners();

            _gameModeTask.RemoveStep(_resultDisplayTask);
            _gameModeTask.RemoveStep(_lowerAudio);
            _gameModeTask.RemoveStep(_fadeOutTask);
        }
    }
}