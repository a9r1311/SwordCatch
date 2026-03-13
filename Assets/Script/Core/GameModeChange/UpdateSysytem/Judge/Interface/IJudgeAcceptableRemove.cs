namespace Kamatte.Core
{
    public interface IJudgeAcceptableRemove    //  差し替えとコンストラクタ抽象化為のBaseClass
    {
        public bool Judge();    //  スタックに対するプッシュが適正かどうか判断する
    }
}