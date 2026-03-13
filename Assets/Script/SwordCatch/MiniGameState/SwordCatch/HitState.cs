namespace Kamatte.SwordCatch
{
    public class HitSwingState    //  白刃取りが失敗したか、成功したかのFlagを持ってる
    {
        bool isHitSwing = false;    //  刀をキャッチした後に、顔に当たって失敗判定になる可能性を消すのに使う

        public bool IsHitSwing
        { get { return isHitSwing; } set { isHitSwing = value; } }

        public void ChagneHitSwordState(bool isHitSwing)    //  振り下ろしをキャッチしたかのFlag、Writerから呼び出される
        {
            IsHitSwing = isHitSwing;
        }
    }
}