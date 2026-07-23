using SwordCatch.Audio;
using SwordCatch.Result;
using SwordCatch.ScreenEffect;
using SwordCatch.Swinger;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SwordCatch.Core
{
    //  機能群の初期化訳役
    [DisallowMultipleComponent]
    public sealed class SceneBootstrap_SwordCatch : MonoBehaviour
    {
        [SerializeField] StateHolder stateHolder;  // 白刃取りの状況を保持しているクラス

        FadeOutStep fadeOutStep;

        ResultDisplayTask resultDisplay;
        [SerializeField] GameObject resultRoot;
        [SerializeField] TextMeshProUGUI playerPowerTxt;
        [SerializeField] TextMeshProUGUI CatchCountTxt;
        [SerializeField] Button RetryButton;

        [SerializeField] SwingerController swingTimeController;
        Swing _swing;

        LowerAudio _lowerAudio;
        [SerializeField] AudioSource BgmSource;

        [SerializeField] PlayerLevelCatalog _levelCatalog;
       
        readonly int _fadeOutOrder = 20;
        readonly int _stopAuidoOrder = 25;
        readonly float _loweredVolume = 0.02f;
        readonly int _resultDisplayOrder = 50;

        GameModeChangeTask _gameModeTask;

        void Awake()
        {
            if (stateHolder == null)
            {
                Debug.LogError("stateHolder isn't assigned in the Inspector");
            }

            fadeOutStep = new FadeOutStep(_fadeOutOrder);
            _lowerAudio = new LowerAudio(_stopAuidoOrder, BgmSource, _loweredVolume);
            resultDisplay = new ResultDisplayTask(_resultDisplayOrder, resultRoot, CatchCountTxt, playerPowerTxt, stateHolder, _levelCatalog);
            _swing = new Swing();
        }

        void Start()
        {
            ServiceLocator.Get<ScreenFade>().FadeIn(1f);

            swingTimeController.Initialize(_swing);
            
            RetryButton.onClick.AddListener(Retry);

            _gameModeTask = ServiceLocator.Get<GameModeChangeTask>();
            _gameModeTask.PushStep(resultDisplay);
            _gameModeTask.PushStep(_lowerAudio);
            _gameModeTask.PushStep(fadeOutStep);
        }

        void Retry()
        {
            ServiceLocator.Get<SceneMgr>().LoadScene(GameMode.SwordCatch);
        }
        void OnDestroy()
        {
            RetryButton.onClick.RemoveAllListeners();

            _gameModeTask.RemoveStep(resultDisplay);
            _gameModeTask.RemoveStep(_lowerAudio);
            _gameModeTask.RemoveStep(fadeOutStep);
        }
    }
}