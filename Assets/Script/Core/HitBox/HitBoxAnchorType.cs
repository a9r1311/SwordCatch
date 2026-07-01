namespace Kamatte.Core
{
    public enum HitBoxAnchor    //  ヒットボックス位置基準
    {
        Transform,   // 所属Transform基準
        Bone,        // ボーン基準（例：右手、頭など）
        World        // ワールド座標固定
    }
}