namespace SwordCatch.Animation
{
    //  刀振りのアニメーターのパラメーター列挙
    public enum SwingerAnimatorParameter
    {
        NormalSwing,  // 通常振り下ろし(Trigger)
        FastSwing,    // 高速振り下ろし(Trigger)
        DelaySwing,   // ディレイ振り下ろし(Trigger)
        IsHit,        // 当たったどうか(Bool)
        IsCought,     // キャッチされたかどうか(Bool)
    }
}