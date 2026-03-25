using System;

namespace Kamatte.Core
{
    public interface IStateMachine<TStateID> where TStateID : Enum    //  インターフェース
    {
        void Initialize() { }    //  初期化
        void Update();    //  State中の処理(Update)
        void FixedUpdate();    //  State中の処理(FixedUpdate)
        void ChangeState(IState<TStateID> nextState);    //  状態変更
    }
}