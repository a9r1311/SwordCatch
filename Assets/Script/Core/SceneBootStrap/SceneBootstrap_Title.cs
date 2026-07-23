using Cysharp.Threading.Tasks;
using UnityEngine;
using SwordCatch.UI;

namespace SwordCatch.Core
{
    //  タイトルシーンの初期化役
    [DisallowMultipleComponent]
    public sealed class SceneBootstrap_Title : MonoBehaviour
    {
        async UniTaskVoid Start()
        {
            await ServiceLocator.Get<UIManager>().ChangeUI(GameStateID.Title);
        }
    }
}