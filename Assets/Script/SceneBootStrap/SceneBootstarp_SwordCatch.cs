using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Kamatte.Core;

namespace Kamatte.SwordCatch
{
    //  機能群の初期化訳役
    [DisallowMultipleComponent]
    public sealed class SceneBootstrap_SwordCatch : MonoBehaviour
    {
        [SerializeField] StateHolder stateHolder;  // 白刃取りの状況を保持しているクラス

        FadeOutStep fadeOutStep;

        ResultDisplay resultDisplay;
        [SerializeField] GameObject resultRoot;
        [SerializeField] TextMeshProUGUI playerPowerTxt;
        [SerializeField] TextMeshProUGUI CatchCountTxt;
        [SerializeField] Button RetryButton;

        [SerializeField] SwingerController swingTimeController;
        Swing _swing;

        StopAudio stopAudio;
        [SerializeField] AudioSource BgmSource;

        GameModeAPIFacadeBase _gameModeAPIFacade;

        void Awake()
        {
            if (stateHolder == null)
            {
                Debug.LogError("stateHolder isn't assigned in the Inspector");
            }

            fadeOutStep = new FadeOutStep();
            resultDisplay = new ResultDisplay(resultRoot, CatchCountTxt, playerPowerTxt, stateHolder);
            stopAudio = new StopAudio(BgmSource);
            _swing = new Swing();
        }

        void Start()
        {
            ServiceLocator.Resolve<ScreenFade>().FadeIn(1f);

            swingTimeController.Initialize(_swing);
            
            RetryButton.onClick.AddListener(Retry);

            _gameModeAPIFacade = ServiceLocator.Resolve<GameModeAPIFacadeBase>();
            _gameModeAPIFacade.pushTask.PushStep(resultDisplay);
            _gameModeAPIFacade.pushTask.PushStep(stopAudio);
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
            _gameModeAPIFacade.removeTask.RemoveStep(stopAudio);
            _gameModeAPIFacade.removeTask.RemoveStep(fadeOutStep);
        }
    }
}