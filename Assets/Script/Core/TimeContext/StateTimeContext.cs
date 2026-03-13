namespace Kamatte.Core
{
    public abstract class StateTimeContext    //  タイムコンテキスト基底クラス
    {
        protected TimeContext _time = new TimeContext();

        public virtual void Enter()
        {
            _time.Reset();
        }

        public virtual void Tick(float deltaTime)
        {
            _time.Tick(deltaTime);
        }

        public virtual void Exit()
        {
            // 状態が終わる時に必要なら後処理
        }

        public float CurrentFrame => _time.CurrentFrame;
    }
}