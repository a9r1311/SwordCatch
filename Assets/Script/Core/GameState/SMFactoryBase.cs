using System;
using System.Collections.Generic;

namespace Kamatte.Core
{
    public abstract class SMFactoryBase<TStateID> : IStateFactory<TStateID> where TStateID : Enum    //  ステートマシーンファクトリ基底クラス
    {
        protected readonly Dictionary<TStateID, Func<IState<TStateID>>> _stateRegistry = new();    //  ステートレジストリ辞書

        public IState<TStateID> CreateState(TStateID stateID)    //  ステートを生成
        {
            if(_stateRegistry.TryGetValue(stateID, out Func<IState<TStateID>> creator))
                {  return creator(); }

            throw new Exception("_state is not registed");
        }

        protected void Register(TStateID id, Func<IState<TStateID>> ceator)    //  生成関数登録
        {
            _stateRegistry[id] = ceator;
        }
    }
}