using SwordCatch.Core;

namespace SwordCatch.UI
{
    public class UIManageFacade : IUIManageFacade
    {
        UIManager uiManager;    //  UIをモード単位で変更するクラス

        public UIManageFacade(UIManager uiManager)
        {
            this.uiManager = uiManager;
        }

        public void ChangeUI(GameStateID stateID)    //  UI変更窓口関数
        {
            uiManager.ChangeUI(stateID);
        }
    }
}