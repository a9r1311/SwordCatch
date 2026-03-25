using System;

namespace Kamatte.Core
{
    public abstract class StateMachineBase<TStateID> : IStateMachine<TStateID>, IState<TStateID> where TStateID : Enum    //  ステートマシーンベースクラス
    {
        protected IState<TStateID> _currentState;

        public virtual void Initialize(IStateFactory<TStateID> factory) { }     //  初期化
        public virtual void Update() => _currentState?.OnUpdate();              //  実行中の処理(Update)
        public virtual void FixedUpdate() => _currentState?.OnFixedUpdate();    //  実行中の処理(FixedUpdate)
        public virtual void ChangeState(IState<TStateID> nextState)             //  状態変更
        {
            _currentState?.OnExit();
            _currentState = nextState;
            _currentState?.OnEnter();
        }
        public virtual void OnEnter() { }     //  ステート突入時の処理
        public virtual void OnUpdate() { }    //  ステート中の処理
        public virtual void OnFixedUpdate() { }    //  ステート中の処理
        public virtual void OnExit() { }     //  ステート脱出時の処理
    }
}