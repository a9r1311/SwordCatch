using System;
using UnityEngine;
using SwordCatch.Core;

namespace SwordCatch.UI
{
    //  SceneIDとUIIDを変換するためのMap
    [CreateAssetMenu(fileName = "SceneIDCovert" ,menuName = "UI/SceneIDConvert")]
    public sealed class SceneIDConvert : ScriptableObject
    {
        //  GameStateIDとuiID変換用Map
        [Serializable]
        public struct Mapping
        {
            public GameStateID sceneID;
            public UIID uiID;
        }

        [SerializeField] Mapping[] _mappings;


        //  SceneIDに対応するUIIDを抽出する
        public bool TryGetUIID(GameStateID sceneID, out UIID controllerID)
        {
            foreach (var map in _mappings)
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