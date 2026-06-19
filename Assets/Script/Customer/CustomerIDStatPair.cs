using UnityEngine;
using System.Collections.Generic;

namespace Kamatte.Customer
{
    [CreateAssetMenu(fileName = "CustomerStat", menuName = "SwordCatch/Customer/Stat")]

    //  お客さんの能力値
    public sealed class CustomerIDStatPair : ScriptableObject, ISerializationCallbackReceiver
    {

        //  敵のIDと能力値のクラス
        [System.Serializable]
        public class CustomerIDStat
        {
            public CustomerID customerName;    //  お客さんのID
            public CustomerStatBlock stat;    //  能力値
        }

        [Header("お客さんの能力値リスト")]
        [SerializeField] List<CustomerIDStat> _customerIDStatList = new();    //  IDと能力値のリスト(インスペクター用)
        Dictionary<CustomerID, CustomerStatBlock> _statMap = new();    //  IDと能力値の辞書(処理用)

        public void OnAfterDeserialize()
        {
            //  能力値辞書の構築
            BuildStatMap();
        }
        public void OnBeforeSerialize() { }

        //  能力値辞書の構築
        void BuildStatMap()
        {
            _statMap.Clear();
            foreach (var pair in _customerIDStatList)
            {
                if (!_statMap.ContainsKey(pair.customerName))
                {
                    _statMap.Add(pair.customerName, pair.stat);
                }
            }
        }

        //  IDに応じた能力値の取得
        public CustomerStatBlock GetStat(CustomerID customerName)
        {
            return _statMap.TryGetValue(customerName, out CustomerStatBlock stat) ? stat : null;
        }
    }
}