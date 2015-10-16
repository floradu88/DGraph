using System;
using DGraph.Core.Import;

namespace DGraph.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Runner runner = new Runner();
            Console.WriteLine(runner.Run(args));
        }
    }
}
