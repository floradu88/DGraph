using System;
using DGraph.Core.Configuration;
using DGraph.Core.Import;
using DGraph.Core.Repository;

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
