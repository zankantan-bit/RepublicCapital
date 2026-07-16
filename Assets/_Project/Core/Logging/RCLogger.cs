using UnityEngine;

namespace RepublicCapital.Core.Logging
{
    public static class RCLogger
    {
        private const string Prefix = "[Republic Capital] ";

        public static void Log(string message)
        {
            Debug.Log(Prefix + message);
        }

        public static void Warning(string message)
        {
            Debug.LogWarning(Prefix + message);
        }

        public static void Error(string message)
        {
            Debug.LogError(Prefix + message);
        }
    }
}