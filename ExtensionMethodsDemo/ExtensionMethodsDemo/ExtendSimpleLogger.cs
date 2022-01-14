using System;

namespace ExtensionMethodsDemo
{
    public static class ExtendSimpleLogger
    {
        public static void LogError(this ISimpleLogger logger, string message)
        {
            var defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            logger.Log(message, "Error");
            Console.ForegroundColor = defaultColor;
        }

        public static void LogWarning(this ISimpleLogger logger, string message)
        {
            var defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            logger.Log(message, "Warning");
            Console.ForegroundColor = defaultColor;
        }
    }
}
