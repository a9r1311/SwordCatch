using System;
using System.Collections.Generic;

namespace Kamatte.Core
{
    public static class SceneNameMap
    {
        private static readonly Dictionary<GameMode, string> map = new()
    {
        { GameMode.Title, "TitleScene" },
        { GameMode.SwordCatch, "SwordCatchScene" },
    };

        public static string GetName(GameMode id)
        {
            if (!map.TryGetValue(id, out string name))
                throw new ArgumentException($"SceneID '{id}' はマッピングされていません。");

            return name;
        }

        public static IEnumerable<GameMode> All => map.Keys;
    }
}