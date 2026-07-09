using UnityEngine;
using UnityEngine.UI;

namespace Kamatte.Core
{
    public class ScrennFadeSystemBootstrap : MonoBehaviour    //  画面をフェードさせるシステムの初期化役
    {
        ScreenFadeFacade screenFadeFacade;    //  システム窓口Class
        ScreenFade screenFader;    //  フェード関数持ちクラス

        [SerializeField] CanvasGroup canvasGroup;
        [SerializeField] Canvas canvas;
        [SerializeField] Image fadeImage;

        private void Awake()
        {
            screenFader = new ScreenFade(canvasGroup, canvas, fadeImage);
            screenFadeFacade = new ScreenFadeFacade(screenFader);
            
            DontDestroyOnLoad(canvas);
        }

        private void Start()
        {
            ServiceLocator.Register<IScreenFadeFacade>(screenFadeFacade);
        }
    }
}