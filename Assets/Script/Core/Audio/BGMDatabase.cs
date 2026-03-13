//using System.Collections.Generic;
//using UnityEngine;

//namespace Kamatte.Core
//{
//    [CreateAssetMenu(fileName = "BGMDatabase", menuName = "Audio/BGM Database")]
//    public class BGMDatabase : ScriptableObject    //  BGMDatabaseÇÃSO
//    {
//        [SerializeField]
//        private List<BGMData> bgmList;

//        private Dictionary<BGMKey, BGMData> _map;

//        public void Build()    //  é´èëìoò^
//        {
//            _map = new Dictionary<BGMKey, BGMData>(bgmList.Count);

//            foreach (var bgm in bgmList)
//            {
//                var key = BGMKeyGenerator.Generate(bgm);
//                _map.Add(key, bgm);
//            }
//        }

//        public BGMData Get(BGMKey key)
//        {
//            return _map[key];
//        }

//        public BGMKey ResoloveKey(BGMData data)
//        {
//            return BGMKeyGenerator.Generate(data);
//        }
//    }
//}