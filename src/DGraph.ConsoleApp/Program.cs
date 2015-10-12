using System;
using DGraph.Core.Import;

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
