using System;
using System.Collections.Generic;

namespace Kamatte.Core
{
    public static class SceneNameMap
    {
        private static readonly Dictionary<SceneID, string> map = new()
    {
        { SceneID.Title, "TitleScene" },
        { SceneID.Shop, "SwordCatchScene" },
    };

        public static string GetName(SceneID id)
        {
            if (!map.TryGetValue(id, out string name))
                throw new ArgumentException($"SceneID '{id}' はマッピングされていません。");

            return name;
        }

        public static IEnumerable<SceneID> All => map.Keys;
    }
}