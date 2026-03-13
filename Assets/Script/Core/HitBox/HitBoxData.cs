using UnityEngine;

namespace Kamatte.Core
{
    [System.Serializable]
    public class HitBoxData    //  当たり判定基礎データ
    {
        [Header("識別情報")]
        public HitBoxID id;   // ← 識別子（例："LeftHand", "RightHand", "Kick"など）

        [Header("参照基準")]
        public HitBoxAnchorType anchorType;    //  生成位置基準のタイプ

        [Header("判定位置とサイズ")]
        public Vector3 offset;    //  生成位置オフセット
        public Vector3 size;      //  当たり判定の大きさ

        [Header("固定位置")]
        public Vector3 worldCenter;    //  World座標を基準にするときの座標

        [Header("ボーン")]
        public Transform boneTransform;    //   Boneを基準にして生成するときのTransform
    }
}