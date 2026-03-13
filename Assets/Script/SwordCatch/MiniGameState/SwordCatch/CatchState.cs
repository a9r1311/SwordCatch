namespace Kamatte.SwordCatch
{
    public class CatchState    //  白刃取りが失敗したか、成功したかの情報を持ってる
    {
        int catchSuccessTime = 0;
        bool isCatchSword = false;    //  刀をキャッチした後に、顔に当たって失敗判定になる可能性を消すのに使う

        public int CatchSuccessTime
        { get { return catchSuccessTime; } }
        public bool IsCatchSword
        { get { return isCatchSword; } set { isCatchSword = value; } }

        public void AddSuccessCount()    //  リザルトで表示する成功回数をインクリメントする
        {
            catchSuccessTime++;
        }

        public void ChagneCatchSwordState(bool isCatchSwing)    //  振り下ろしをキャッチしたかのFlag、Writerから呼び出される
        {
            isCatchSword = isCatchSwing;
        }
    }
}