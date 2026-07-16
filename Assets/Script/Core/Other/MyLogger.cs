using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Kamatte.Core
{
    public static class MyLogger
    {
        [Conditional("UNITY_EDITOR")]
        public static void Log(object message, [CallerFilePath] string filePath = "", [CallerLineNumber] int line = 0)
        {
            UnityEngine.Debug.Log($"{message} (from {filePath}:{line})");
        }
        
        [Conditional("UNITY_EDITOR")]
        public static void WarningLog(object message, [CallerFilePath] string filePath = "", [CallerLineNumber] int line = 0)
        {
            UnityEngine.Debug.LogWarning($"{message} (from {filePath}:{line})");
        }

        [Conditional("UNITY_EDITOR")]
        public static void ErrorLog(object message, [CallerFilePath] string filePath = "", [CallerLineNumber] int line = 0)
        {
            UnityEngine.Debug.LogError($"{message} (from {filePath}:{line})");
        }
    }
}