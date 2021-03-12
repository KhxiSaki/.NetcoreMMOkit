using System;

namespace MMO.ConsoleTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Services.SimpleTest.SeedTestData();

            Console.ReadLine();
        }
    }
}
