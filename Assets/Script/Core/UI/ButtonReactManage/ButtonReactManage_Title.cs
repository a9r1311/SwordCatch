using UnityEngine;

namespace Kamatte.Core
{
    public class ButtonReactManage_Title : MonoBehaviour, IUIController    //  タイトル画面のボタンに反応を入れる
    {
        [SerializeField] private ButtonManager buttonManager;
        [SerializeField] private GameObject TutorialRoot;

        //  ボタン初期化
        public void Init()
        {
            // ボタン登録など
            buttonManager.RegistReact(ButtonID.GoPlayButton, OnGoPlayPressed);
            buttonManager.RegistReact(ButtonID.TutorialButton, DisplayTutorial);

            // UI初期状態の設定など
            buttonManager.EnableAllButtons();
        }

        //    ボタン初期化解除
        public void Deinit()
        {
            // ボタンのイベント解除（※ Unregister を実装しておく）
            buttonManager.UnregistReact(ButtonID.GoPlayButton);

            // UIの一時非表示や状態クリアなど
            buttonManager.DisableAllButtons();
        }

        //  ゲーム開始を押したときの処理
        async void OnGoPlayPressed()
        {
            buttonManager.SetInteractable(ButtonID.GoPlayButton, false);
            await ServiceLocator.Resolve<IScreenFadeFacade>().FadeOut(1f);
            SceneUtility.LoadScene(SceneNameMap.GetName(SceneID.Shop));
        }

        void DisplayTutorial()
        {
            TutorialRoot.SetActive(true);
        }

        void OnExitPressed()
        {
            // アプリ終了処理
        }
    }
}