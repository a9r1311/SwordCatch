using System.Collections.Generic;
using UnityEngine;

namespace Kamatte.Core
{
    //   オブジェクトデータベース
    [CreateAssetMenu(fileName = "ObjectDatabase", menuName = "GameData/ID Object Database")]
    public sealed class ObjectDatabase : ScriptableObject
    {
        [Header("オブジェクトID(Toolから取得)")]
        [SerializeField] private List<string> ObjectIDs = new();    //  オブジェクトIDリスト

        //  ObjectIdsプロパティ
        public List<string> ObjectIDsProperty => ObjectIDs;

        //  オブジェクトIDを一括設定
        public void SetIDs(List<string> IDs)
        {
            ObjectIDs = IDs;
        }
    }
}