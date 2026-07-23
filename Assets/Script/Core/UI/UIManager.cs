using SwordCatch.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwordCatch.UI
{
    public class UIManager    //  包括的なUI管理をするクラス
    {
        private UIFactory uiFactory;    //  UIObjcetのRootが詰まってるSO

        private Dictionary<GameStateID, IUIController> uiCache = new();

        private IUIController currentUIController;

        //  --  Public method

        public UIManager(UIFactory uiFactory)
        {
            this.uiFactory = uiFactory;
        }

        //  ゲームステート単位でUIを変更する
        public async Task ChangeUI(GameStateID gameStateID)
        {
            currentUIController?.Deinit();    //  現在のUIを無効果

            if (!uiCache.TryGetValue(gameStateID, out var ui))
            {
                ui = await uiFactory.CreateUI(gameStateID);
                uiCache[gameStateID] = ui;
            }

            currentUIController = ui;
            currentUIController.Init();    //  新しいUIを初期化
        }
    }
}