using SwordCatch.Core;
using SwordCatch.ScreenEffect;
using UnityEngine;

namespace SwordCatch.UI
{
    //  タイトル画面のボタンに反応を入れる
    [DisallowMultipleComponent]
    public sealed class ButtonReactManage_Title : MonoBehaviour, IUIController
    {
        [SerializeField] ButtonManager _buttonManager;
        [SerializeField] GameObject _tutorialRoot;

        [SerializeField] SceneMapping _sceneMapping;

        //  ボタン初期化
        public void Init()
        {
            // ボタン登録など
            _buttonManager.RegistReact(ButtonID.GoPlayButton, OnGoPlayPressed);
            _buttonManager.RegistReact(ButtonID.TutorialButton, DisplayTutorial);

            // UI初期状態の設定など
            _buttonManager.EnableAllButtons();
        }

        //    ボタン初期化解除
        public void Deinit()
        {
            // ボタンのイベント解除（※ Unregister を実装しておく）
            _buttonManager.UnregistReact(ButtonID.GoPlayButton);

            // UIの一時非表示や状態クリアなど
            _buttonManager.DisableAllButtons();
        }

        //  ゲーム開始を押したときの処理
        async void OnGoPlayPressed()
        {
            _buttonManager.SetInteractable(ButtonID.GoPlayButton, false);
            await ServiceLocator.Get<ScreenFade>().FadeOut(1f);
            ServiceLocator.Get<SceneMgr>().LoadScene(GameMode.SwordCatch);
        }

        void DisplayTutorial()
        {
            _tutorialRoot.SetActive(true);
        }
    }
}