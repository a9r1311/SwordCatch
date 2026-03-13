namespace Kamatte.Core
{
    public enum EffectActType    //  演出用動きのタイプ
    {
        Blow    //  吹き飛ばし
    }

    public enum EffectActTrigger    //  演出用動きのトリガー
    {
        Hit    //  当たったことによる動き
    }
    [System.Serializable]
    public enum EffectActor    //  演じる対象
    {
        Player,
    }
}