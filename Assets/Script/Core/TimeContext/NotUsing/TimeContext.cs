namespace Kamatte.Core
{
    public class TimeContext    //  時間基本情報
    {
        public const float FRAME_RATE = 60f;    //  フレームレート

        public float DeltaTime { get; private set; }
        public float ElapsedTime { get; private set; }

        public void Tick(float deltaTime)    //  時間更新
        {
            DeltaTime = deltaTime;
            ElapsedTime += deltaTime;
        }
        public void Reset()    //  時間リセット
        {
            ElapsedTime = 0f;
        }

        public float CurrentFrame => ElapsedTime * FRAME_RATE;
    }
}
