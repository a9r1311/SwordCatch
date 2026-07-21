namespace SwordCatch.HitBox
{
    // ヒットボックス位置基準
    public enum HitBoxAnchorType
    {
        Transform,   // 所属Transform基準
        Bone,        // ボーン基準（例：右手、頭など）
        World        // ワールド座標固定
    }
}