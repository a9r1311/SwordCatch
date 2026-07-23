using SwordCatch.Core;
using UnityEngine;

namespace SwordCatch.UI
{
    public class UIManageSystemBootstrap : MonoBehaviour   //  UI変更システムの初期化役
    {
        [SerializeField] UIFactory uiFactory;    //  UIObjectのRootが詰まったSO

        IUIManageFacade manageFacade;    //  ServiceLocatorに登録する窓口クラス
        UIManager uiManager;    //  UIを変更するクラス

        void Awake()
        {
            uiManager = new UIManager(uiFactory);
            manageFacade = new UIManageFacade(uiManager);

            ServiceLocator.Register<IUIManageFacade>(manageFacade);
        }
    }
}