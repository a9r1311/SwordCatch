using UnityEngine;

namespace Kamatte.Core
{
    public class UIManageSystemBootstrap : MonoBehaviour   //  UI変更システムの初期化役
    {
        [SerializeField] UIFactory uiFactory;    //  UIObjectのRootが詰まったSO

        IUIManageJudge uiManageJudge;    //  UI変更をしていいかを判断するクラス
        IUIManageFacade manageFacade;    //  ServiceLocatorに登録する窓口クラス
        UIManager uiManager;    //  UIを変更するクラス

        void Awake()
        {
            uiManageJudge = new UIManageJudge();
            uiManager = new UIManager(uiFactory);
            manageFacade = new UIManageFacade(uiManager, uiManageJudge);
        }

        void Start()
        {
            ServiceLocator.Register<IUIManageFacade>(manageFacade);
        }
    }
}