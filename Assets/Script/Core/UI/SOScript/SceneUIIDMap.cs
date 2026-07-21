using System;
using UnityEngine;
using SwordCatch.Core;

namespace SwordCatch.UI
{
    [CreateAssetMenu(fileName = "SceneIDCovert" ,menuName = "UI/SceneIDConvert")]
    public class SceneIDConvert : ScriptableObject    //  SceneIDとUIIDを変換するためのMap
    {
        [Serializable]
        public struct Mapping    //  GameStateIDとuiID変換用Map
        {
            public GameStateID sceneID;
            public UIID uiID;
        }

        [SerializeField] private Mapping[] mappings;

        //  --  Public method

        //  SceneIDに対応するUIIDを抽出する
        public bool TryGetUIID(GameStateID sceneID, out UIID controllerID)
        {
            foreach (var map in mappings)
            {
                if (map.sceneID == sceneID)
                {
                    controllerID = map.uiID;
                    return true;
                }
            }

            controllerID = default;
            return false;
        }
    }
}