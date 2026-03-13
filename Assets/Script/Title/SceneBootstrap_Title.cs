using UnityEngine;

namespace Kamatte.Core
{
    public class SceneBootstrap_Title : MonoBehaviour    //  タイトルシーンの初期化役
    {

        //  --  UnityLifeCycle

        void Start()
        {
            ServiceLocator.Resolve<IUIManageFacade>().ChangeUI(GameStateID.Title);
        }
    }
}