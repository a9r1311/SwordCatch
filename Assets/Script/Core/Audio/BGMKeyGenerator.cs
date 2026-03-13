//using UnityEditor;

//namespace Kamatte.Core
//{
//    public class BGMKeyGenerator    //  BGMKeyを生成するクラス
//    {
//        //  ----  外部API

//        public static BGMKey Generate(BGMData bgm)    //  BGM生成外部API
//        {
//            string guid = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(bgm));    // GUID を取得

//            int hash = HashAPI.StableHash(guid);
//            return new BGMKey(hash);
//        }
//    }
//}