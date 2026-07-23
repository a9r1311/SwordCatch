using UnityEngine;
using SwordCatch.Core;

namespace SwordCatch.UI
{
    //  UI変更システムの初期化役
    public sealed class UIManagerBootstrap : MonoBehaviour
    {
        // UIObjectが詰まったScirptableObject
        [SerializeField] UIFactory uiFactory;
        //  UIを変更するクラス
        UIManager _uiManager;

        void Awake()
        {
            _uiManager = new UIManager(uiFactory);
            ServiceLocator.Register<UIManager>(_uiManager);
        }
    }
}