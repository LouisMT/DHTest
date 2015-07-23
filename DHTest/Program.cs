using System;

namespace DHTest
{
    class Program
    {
        private const int Pow = 3;
        private const int Mod = 17;
        private const ConsoleColor IsMatchConsoleForegroundColor = ConsoleColor.Green;
        private const ConsoleColor NoMatchConsoleForegroundColor = ConsoleColor.Red;
        private const ConsoleColor DefaultConsoleForegroundColor = ConsoleColor.White;
        private const ConsoleColor DefaultConsoleBackgroundColor = ConsoleColor.Black;

        private static void Main(string[] args)
        {
            var random = new Random();
            Console.BackgroundColor = DefaultConsoleBackgroundColor;
            Console.ForegroundColor = DefaultConsoleForegroundColor;
            Console.Clear();

            Console.WriteLine("Using ^{0} and %{1}...", Pow, Mod);

            while (true)
            {
                Console.WriteLine();

                var privateA = random.Next();
                var privateB = random.Next();
                DebugVariables("Private", privateA, privateB);

                var publicA = Pow ^ privateA % Mod;
                var publicB = Pow ^ privateB % Mod;
                DebugVariables("Public", publicA, publicB);

                var sharedA = publicB ^ privateA % Mod;
                var sharedB = publicA ^ privateB % Mod;
                DebugVariables("Shared", sharedA, sharedB);

                Console.ReadKey();
            }
        }

        static void DebugVariables(string name, int a, int b)
        {
            Console.WriteLine("{0}:", name);
            Console.Write(" > ");
            Console.ForegroundColor = (a == b) ?
                IsMatchConsoleForegroundColor :
                NoMatchConsoleForegroundColor;
            Console.WriteLine(a);
            Console.ForegroundColor = DefaultConsoleForegroundColor;
            Console.Write(" > ");
            Console.ForegroundColor = (a == b) ?
                IsMatchConsoleForegroundColor :
                NoMatchConsoleForegroundColor;
            Console.WriteLine(b);
            Console.ForegroundColor = DefaultConsoleForegroundColor;
        }
    }
}
