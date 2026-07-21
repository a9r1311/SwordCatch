namespace SwordCatch.CharacterPerformance
{
    // パフォーマンス種類
    public enum PerformaceType
    {
        Blow  // 吹き飛び
    }

    //  パフォーマンストリガー
    public enum EffectActTrigger
    {
        HitSword  // 白刃取り失敗
    }

    //  パフォーマー
    [System.Serializable]
    public enum Performer
    {
        Player,  // プレイヤー
    }
}