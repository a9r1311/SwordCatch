using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UAssert = UnityEngine.Assertions.Assert;

namespace Kamatte.Core
{
    //  画面フェードクラス
    public sealed class ScreenFade
    {
        CanvasGroup _canvasGroup;
        Canvas _canvas;
        Image _fadeImage;

        public ScreenFade(CanvasGroup canvasGroup, Canvas canvas, Image fadeImage)
        {
            UAssert.IsNotNull(canvasGroup, "キャンバスグループの参照がnullです。");
            UAssert.IsNotNull(canvas, "キャンバスの参照がNullです。");
            UAssert.IsNotNull(fadeImage, "フェードイメージがNullです。");

            _canvasGroup = canvasGroup;
            _canvas = canvas;
            _fadeImage = fadeImage;

            InitializeSetting(0f);
        }

        public void InitializeSetting(float imageAlpha)
        {
            _canvasGroup.alpha = imageAlpha;
            _fadeImage.raycastTarget = false;
        }

        //  フェードアウト
        public Task FadeOut(float duration, Color? fadeColor = null)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            SetFadeColor(fadeColor ?? Color.black);
            ServiceLocator.Get<CoroutineRunner>().StartCoroutine(FadeCoroutine(0f, 1f, duration, tcs));
            return tcs.Task;
        }

        //  フェードイン
        public Task FadeIn(float duration)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            ServiceLocator.Get<CoroutineRunner>().StartCoroutine(FadeCoroutine(1f, 0f, duration, tcs));
            return tcs.Task;
        }

        //  フェードの色をセット
        void SetFadeColor(Color color)
        {
            _fadeImage.color = color;
        }

        //  フェードコルーチン
        IEnumerator FadeCoroutine(float from, float to, float duration, TaskCompletionSource<bool> tcs)
        {
            _canvasGroup.blocksRaycasts = true;
            _canvas.enabled = true;

            float elapsed = 0f;
            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float t = Mathf.Clamp01(elapsed / duration);
                float alpha = Mathf.Lerp(from, to, t);
                _canvasGroup.alpha = alpha;
                yield return null;
            }

            _canvasGroup.alpha = to;

            if (Mathf.Approximately(to, 0f))
            {
                _canvas.enabled = false;
                _canvasGroup.blocksRaycasts = false;
            }

            tcs.SetResult(true);
        }

        public void Deinit()
        {
            //  初期化解除処理
        }
    }
}