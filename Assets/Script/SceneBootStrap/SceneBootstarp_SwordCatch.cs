using Kamatte.Core;
using SwordCatch.Audio;
using SwordCatch.Result;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kamatte.SwordCatch
{
    //  機能群の初期化訳役
    [DisallowMultipleComponent]
    public sealed class SceneBootstrap_SwordCatch : MonoBehaviour
    {
        [SerializeField] StateHolder stateHolder;  // 白刃取りの状況を保持しているクラス

        FadeOutStep fadeOutStep;

        ResultDisplayStep resultDisplay;
        [SerializeField] GameObject resultRoot;
        [SerializeField] TextMeshProUGUI playerPowerTxt;
        [SerializeField] TextMeshProUGUI CatchCountTxt;
        [SerializeField] Button RetryButton;

        [SerializeField] SwingerController swingTimeController;
        Swing _swing;

        LowerAudio _lowerAudio;
        [SerializeField] AudioSource BgmSource;

        GameModeAPIFacade _gameModeAPIFacade;

        [SerializeField] PlayerLevelCatalog _levelCatalog;
       
        readonly int _fadeOutOrder = 20;
        readonly int _stopAuidoOrder = 25;
        readonly float _loweredVolume = 0.02f;
        readonly int _resultDisplayOrder = 50;

        void Awake()
        {
            if (stateHolder == null)
            {
                Debug.LogError("stateHolder isn't assigned in the Inspector");
            }

            fadeOutStep = new FadeOutStep(_fadeOutOrder);
            _lowerAudio = new LowerAudio(_stopAuidoOrder, BgmSource, _loweredVolume);
            resultDisplay = new ResultDisplayStep(_resultDisplayOrder, resultRoot, CatchCountTxt, playerPowerTxt, stateHolder, _levelCatalog);
            _swing = new Swing();
        }

        void Start()
        {
            ServiceLocator.Get<ScreenFade>().FadeIn(1f);

            swingTimeController.Initialize(_swing);
            
            RetryButton.onClick.AddListener(Retry);

            _gameModeAPIFacade = ServiceLocator.Get<GameModeAPIFacade>();
            _gameModeAPIFacade.pushTask.PushStep(resultDisplay);
            _gameModeAPIFacade.pushTask.PushStep(_lowerAudio);
            _gameModeAPIFacade.pushTask.PushStep(fadeOutStep);
        }

        void Retry()
        {
            SceneUtility.LoadScene(SceneNameMap.GetName(SceneID.Shop));
        }
        void OnDestroy()
        {
            RetryButton.onClick.RemoveAllListeners();

            _gameModeAPIFacade.removeTask.RemoveStep(resultDisplay);
            _gameModeAPIFacade.removeTask.RemoveStep(_lowerAudio);
            _gameModeAPIFacade.removeTask.RemoveStep(fadeOutStep);
        }
    }
}