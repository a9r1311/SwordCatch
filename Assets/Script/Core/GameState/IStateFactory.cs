using System;

namespace Kamatte.Core
{
    public interface IStateFactory<TStateID> where TStateID : Enum    //  ステートファクトリインターフェース
    {
        IState<TStateID> CreateState(TStateID stateID);         //  ステートマシーン作成
    }
}