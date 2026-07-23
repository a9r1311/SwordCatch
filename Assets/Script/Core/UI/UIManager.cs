using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using SwordCatch.Core;

namespace SwordCatch.UI
{
    //  UIä«óùÇÇ∑ÇÈÉNÉâÉX
    public sealed class UIManager
    {
        UIFactory _uiFactory;  // UIÇ™ãlÇ‹Ç¡ÇƒÇÈScriptableObject

        Dictionary<GameStateID, IUIController> _uiCache = new();
        IUIController _currentUIController;

        public UIManager(UIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        //  UIïœçX
        public async UniTask ChangeUI(GameStateID gameStateID)
        {
            //  åªç›ÇÃUIÇñ≥å¯â 
            _currentUIController?.Deinit();

            if (!_uiCache.TryGetValue(gameStateID, out var ui))
            {
                ui = await _uiFactory.CreateUI(gameStateID);

                if (ui == null)
                {
                    MyLogger.ErrorLog($"UIê∂ê¨Ç…é∏îsÇµÇ‹ÇµÇΩ: {gameStateID}");
                    return;
                }

                _uiCache[gameStateID] = ui;
            }

            _currentUIController = ui;
            _currentUIController.Init();
        }
    }
}