using UnityEngine;
using UnityEngine.UI;
using UAssert = UnityEngine.Assertions.Assert;

namespace Kamatte.Core
{
    //  画面をフェードさせるシステムの初期化役
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(-10)]
    public sealed class ScrennFadeSystemBootstrap : MonoBehaviour
    {
        [SerializeField] CanvasGroup _canvasGroup;
        [SerializeField] Canvas _canvas;
        [SerializeField] Image _fadeImage;
        
        ScreenFade _screenFader;  // フェード関数持ちクラス

        void Awake()
        {
            UAssert.IsNotNull(_canvasGroup, "CanvasGroupの参照がありません");
            UAssert.IsNotNull(_canvas, "Canvasの参照がありません");
            UAssert.IsNotNull(_fadeImage, "fadeImageの参照がありません");
            _screenFader = new ScreenFade(_canvasGroup, _canvas, _fadeImage);
            
            DontDestroyOnLoad(_canvas);

            ServiceLocator.Register<ScreenFade>(_screenFader);
        }
    }
}