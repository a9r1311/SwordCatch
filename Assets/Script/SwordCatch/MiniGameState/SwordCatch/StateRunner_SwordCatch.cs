using UnityEngine;

namespace Kamatte.SwordCatch
{
    //  ゲームの状態を持つクラス
    [DisallowMultipleComponent]
    [RequireComponent(typeof(StateSystemBootstrap))]
    public sealed class StateHolder : MonoBehaviour
    {
        int _catchSuccessCnt = 0;    //  白刃取り成功回数
        bool _isCatchSword = false;  //  白刃取りをしたかどうか
        
        bool _isHitSwing = false;  // 振り下ろしに当たったかどうか
        
        public int CatchSuccessCnt
        { get { return _catchSuccessCnt; } }
        
        public bool IsCatchSword
        { get { return _isCatchSword; } set { _isCatchSword = value; } }

        public bool IsHitSwing
        { get { return _isHitSwing; } set { _isHitSwing = value; } }

        public void CatchSuccess()  // リザルトで表示する成功回数をインクリメントする
        {
            _catchSuccessCnt++;
        }
    }
}