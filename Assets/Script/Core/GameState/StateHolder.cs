using UnityEngine;

namespace SwordCatch.Core
{
    //  ゲーム状態を保持しているクラス
    [DisallowMultipleComponent]
    public sealed class StateHolder : MonoBehaviour
    {
        int _catchSuccessCnt = 0;  // 白刃取り成功回数
        bool _isCatchSword = false;  // 白刃取り成功したかどうか
        bool _isHitSwing = false;  // 振り下ろしに当たったかどうか

        public int CatchSuccessCnt
        { get { return _catchSuccessCnt; } }
        
        public bool IsCatchSword
        { get { return _isCatchSword; } set { _isCatchSword = value; } }

        public bool IsHitSwing
        { get { return _isHitSwing; } set { _isHitSwing = value; } }

        // キャッチ成功処理
        public void CatchSuccess()
        {
            IsCatchSword = true;
            _catchSuccessCnt++;
        }
    }
}