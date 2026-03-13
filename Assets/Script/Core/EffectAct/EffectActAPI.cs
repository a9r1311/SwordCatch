namespace Kamatte.Core
{
    public static class EffectActAPI    //  プレイヤーに演出のための動きさせるための窓口
    {
        public static void Action(EffectActKey key)    //  演出用動き実行
        {
            ServiceLocator.Resolve<IEffectActSystem>().Play(key);
        }
    }
}
