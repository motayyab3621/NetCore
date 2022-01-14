using System;

namespace ExtensionMethodsDemo.Extensions
{
    public static class Extensions
    {
        public static void PrintToConsole(this string message)
        {
            Console.WriteLine(message);
        }
    }
}
