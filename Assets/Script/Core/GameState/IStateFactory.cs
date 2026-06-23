using System;

namespace Kamatte.Core
{
    //  ステートファクトリインターフェース
    public interface IStateFactory<TStateID> where TStateID : Enum
    {
        //  ステート作成
        IState<TStateID> CreateState(TStateID stateID);
    }
}