using DGraph.Core.Import;
using System;
namespace DGraph.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Runner runner = new Runner();
            Console.WriteLine(runner.Run(args));
        }
    }
}
