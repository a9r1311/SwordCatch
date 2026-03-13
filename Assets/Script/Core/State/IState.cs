using System;

namespace Kamatte.Core
{
    public interface IState<TstateID> where TstateID : Enum    //  ステートパターンインターフェース
    {
        void OnEnter();
        void OnUpdate();
        void OnFixedUpdate();
        void OnExit();
    }
}