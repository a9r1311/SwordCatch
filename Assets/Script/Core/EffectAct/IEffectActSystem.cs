namespace Kamatte.Core
{
    public interface IEffectActSystem    //  演出用の動きをさせるシステム
    {
        void Play(EffectActKey key);    //  演出用動き実行させる
    }
}