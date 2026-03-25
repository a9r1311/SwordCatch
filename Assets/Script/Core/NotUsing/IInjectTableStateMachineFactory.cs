namespace Kamatte.Core
{
    public interface IInjectTableStateMachineFactory<TStateID, TStateMachine>    //  後注入可能にするためのInterface
    {
        void InjectStateMachine(TStateMachine stateMachine);    //  StateMachine後注入メソッド
    }
}