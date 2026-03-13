using UnityEngine;
using System.Collections.Generic;

namespace Kamatte.Customer
{
    [CreateAssetMenu(fileName = "CustomerStatus", menuName = "Customer/Status")]

    //  お客さんのステータス
    public class CustomerStatus : ScriptableObject
    {

        //  敵の状態とステータスをもつクラス
        [System.Serializable]
        public class CustomerNameStatusPair
        {
            public CustomerID customerName;    //  敵の状態(通常時と狂暴化)
            public CustomerStatusBlock Stat;    //  ステータスを持つクラス
        }

        [Header("CustomerStatus")]
        public List<CustomerNameStatusPair> CustomerNameStatus = new();    //  状態とステータスを持つクラスのリスト(データ入力用)

        Dictionary<CustomerID, CustomerStatusBlock> StatusMap;    //  状態とステータスの辞書(処理用)

        void OnEnable()
        {
            //  スーテータスマップの初期化
            BuildStatMap();
        }

        //  ステータスマップ初期化
        void BuildStatMap()
        {
            StatusMap = new();
            foreach (var pair in CustomerNameStatus)
            {
                if (!StatusMap.ContainsKey(pair.customerName))
                {
                    StatusMap.Add(pair.customerName, pair.Stat);
                }
            }
        }

        //  状態に応じたステータスの取得
        public CustomerStatusBlock GetStats(CustomerID customerName)
        {
            return StatusMap.TryGetValue(customerName, out CustomerStatusBlock stats) ? stats : null;
        }
    }
}