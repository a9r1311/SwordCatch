using UnityEngine;

namespace Kamatte.Core
{
    //  当たり判定定義クラス
    [System.Serializable]
    public sealed class HitBox
    {
        [Header("ヒットボックスID")]
        public HitBoxID id;

        //[Header("基準地点")]
        //public HitBoxAnchor anchorType;    //  座標の基準のタイプ

        [Header("位置とサイズ")]
        public Vector3 offset;    //  生成位置オフセット
        public Vector3 size;      //  当たり判定の大きさ

        //[Header("ワールド座標")]
        //public Vector3 worldCenter;    //  World座標で扱う際の生成位置

        //[Header("ボーン")]
        //public Transform bone;    //   Bone基準時の対象
    }
}