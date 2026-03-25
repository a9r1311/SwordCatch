namespace Kamatte.Core
{
    public class CatchTimeContext : StateTimeContext    //  白刃取りタイムコンテキスト
    {
        public bool IsCatchWindowActive { get; private set; }

        const int START_FRAME = 10;
        const int END_FRAME = 20;

        public override void Tick(float deltaTime)
        {
            base.Tick(deltaTime);

            float frame = _time.CurrentFrame;

            // 判定有効区間
            IsCatchWindowActive = frame >= START_FRAME && frame <= END_FRAME;
        }
    }
}