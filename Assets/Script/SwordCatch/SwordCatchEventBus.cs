using System;

namespace Kamatte.Core
{
    public class SwordCatchEventBus    //  白刃取りゲームのイベントバス
    {
        public static event Action OnCatchPressed;
        public static event Action OnCatchSuccess;

        public static void RaiseCatchPressed()    //  キャッチkeyが押された時
        {
            OnCatchPressed?.Invoke();
        }
        public static void CatchSuccess()    //  キャッチ成功時の処理
        {
            OnCatchSuccess?.Invoke();
        }
    }
}