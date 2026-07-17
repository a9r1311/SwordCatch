using UnityEngine;

namespace Kamatte.Core
{
    public class SceneBootstrap_Title : MonoBehaviour    //  タイトルシーンの初期化役
    {
        void Start()
        {
            ServiceLocator.Get<IUIManageFacade>().ChangeUI(GameStateID.Title);
        }
    }
}