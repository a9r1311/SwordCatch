using SwordCatch.UI;
using UnityEngine;

namespace SwordCatch.Core
{
    //  タイトルシーンの初期化役
    [DisallowMultipleComponent]
    public sealed class SceneBootstrap_Title : MonoBehaviour
    {
        void Start()
        {
            ServiceLocator.Get<IUIManageFacade>().ChangeUI(GameStateID.Title);
        }
    }
}