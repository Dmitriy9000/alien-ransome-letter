using System;
using AlienRansomeLib;

namespace AlienRansome
{
    class Program
    {
        static void Main(string[] args)
        {
            var alienRansome = new AlienRansomeProblem();
            var solution = alienRansome.SolveUsingDictionary();
            Console.WriteLine(solution);
        }
    }
}
