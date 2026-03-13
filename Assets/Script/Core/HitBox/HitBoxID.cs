using System;

namespace Kamatte.Core
{
    public enum HitBoxID    //  ヒットボックスID
    {
        SwordCatch,    //  白刃取り当たり判定
        Unknown        //  定義なし
    }
}
//[Serializable]
//public readonly struct HitBoxID : IEquatable<HitBoxID>    //  ヒットボックスID
//{
//    public readonly int Value;
//    private HitBoxID(int value) => Value = value;

//    public bool Equals(HitBoxID other) => Value == other.Value;    //  等価比較
//    public override int GetHashCode() => Value;    //  ハッシュコード提供
//    public override bool Equals(object obj) => obj is HitBoxID other && Equals(other);    //  等価比較オーバーライド定義

//    public static readonly HitBoxID None = new(0);
//    public static readonly HitBoxID SwordCatch = new(1);
//    public static readonly HitBoxID Attack1 = new(2);
//    public static readonly HitBoxID Attack2 = new(3);

//    public override string ToString() => Value switch    //  文字列取得オーバーライド
//    {
//        1 => "SwordCatch",
//        2 => "Attack1",
//        3 => "Attack2",
//        _ => "Unknown"
//    };
//}