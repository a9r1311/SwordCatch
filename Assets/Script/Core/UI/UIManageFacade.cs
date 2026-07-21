using SwordCatch.Core;

namespace SwordCatch.UI
{
    public class UIManageFacade : IUIManageFacade
    {
        UIManager uiManager;    //  UIをモード単位で変更するクラス
        IUIManageJudge manageJudge;    //  UI変更していい状態か判断するクラス

        public UIManageFacade(UIManager uiManager, IUIManageJudge manageJudge)
        {
            this.uiManager = uiManager;
            this.manageJudge = manageJudge;
        }

        public void ChangeUI(GameStateID stateID)    //  UI変更窓口関数
        {
            if (manageJudge.Judge())
            {
                uiManager.ChangeUI(stateID);
            }
        }
    }
}