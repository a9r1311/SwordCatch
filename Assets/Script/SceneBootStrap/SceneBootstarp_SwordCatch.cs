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
        SceneStartStepExcuteBase startStepExcute;               //  シーン開始時に必要な処理をするクラス

        [SerializeField] StateHolder stateHolder;    //  ミニゲームのStateを集約してる、Reader層から呼ばれる。
        StateReader_SwordCatch stateReader;                     //  下位クラスからStateClassへのFacade、Judgeインスタンスからアクセス可否を判断する。

        FadeOutStep fadeOutStep;

        ResultDisplay resultDisplay;
        [SerializeField] GameObject resultRoot;
        [SerializeField] TextMeshProUGUI playerPowerTxt;
        [SerializeField] TextMeshProUGUI CatchCountTxt;
        [SerializeField] Button RetryButton;

        [SerializeField] SwingTimeController swingTimeController;
        SwordSwing swordSwing;

        StopAudio stopAudio;
        [SerializeField] AudioSource BgmSource;


        void Awake()
        {
            startStepExcute = new SceneStartStepExcute();
            
            if (stateHolder == null)
            {
                Debug.LogError("stateHolder isn't assigned in the Inspector");
            }

            stateReader = new StateReader_SwordCatch(stateHolder);

            fadeOutStep = new FadeOutStep();
            resultDisplay = new ResultDisplay(resultRoot, CatchCountTxt, playerPowerTxt, stateReader);
            stopAudio = new StopAudio(BgmSource);
            swordSwing = new SwordSwing();
        }

        void Start()
        {
            startStepExcute.StartSteps();

            swingTimeController.Initialize(swordSwing);
            
            RetryButton.onClick.AddListener(Retry);
            ServiceLocator.Resolve<GameModeAPIFacadeBase>().pushTask.PushStep(resultDisplay);
            ServiceLocator.Resolve<GameModeAPIFacadeBase>().pushTask.PushStep(stopAudio);
            ServiceLocator.Resolve<GameModeAPIFacadeBase>().pushTask.PushStep(fadeOutStep);
        }

        void Retry()
        {
            SceneUtility.LoadScene(SceneNameMap.GetName(SceneID.Shop));
        }
        void OnDestroy()
        {
            RetryButton.onClick.RemoveAllListeners();
            ServiceLocator.Resolve<GameModeAPIFacadeBase>().removeTask.RemoveStep(resultDisplay);
            ServiceLocator.Resolve<GameModeAPIFacadeBase>().removeTask.RemoveStep(stopAudio);
            ServiceLocator.Resolve<GameModeAPIFacadeBase>().removeTask.RemoveStep(fadeOutStep);
        }
    }
}