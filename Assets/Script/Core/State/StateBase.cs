using System;

namespace Kamatte.Core
{
    public abstract class StateBase<TStateID> : IState<TStateID> where TStateID : Enum
    {
        protected readonly IStateMachine<TStateID> _machine;

        protected StateBase(IStateMachine<TStateID> machine)
        {
            _machine = machine;
        }

        public virtual void OnEnter() { }
        public virtual void OnUpdate() { }
        public virtual void OnFixedUpdate() { }
        public virtual void OnExit() { }
    }
}