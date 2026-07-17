using UnityEngine;
using Kamatte.Core;

namespace SwordCatch.Core
{
    //  タイトルシーンの初期化役
    [DisallowMultipleComponent]
    public class SceneBootstrap_Title : MonoBehaviour
    {
        void Start()
        {
            ServiceLocator.Get<IUIManageFacade>().ChangeUI(GameStateID.Title);
        }
    }
}