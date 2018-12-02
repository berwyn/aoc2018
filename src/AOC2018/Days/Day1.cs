using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AOC2018.Common;

namespace AOC2018.Days
{
    public static class Day1
    {
        private static readonly string _input;

        static Day1()
        {
            var task = InputCollector.GetInputForDay(1);
            task.Wait();
            _input = task.Result;
        }

        public static void Run()
        {
            var frequency = 0;
            foreach (var change in CalculateChangeSet())
            {
                frequency += change;
            }

            Console.WriteLine($"The result for Day 1 is {frequency}");
        }

        public static void RunPartTwo()
        {
            var calculatedFrequencies = new HashSet<int>();
            var foundFrequency = false;
            var frequency = 0;
            string output = "";

            while (!foundFrequency)
            {
                foreach (var change in CalculateChangeSet())
                {
                    var result = frequency + change;
                    if (calculatedFrequencies.Contains(result))
                    {
                        output = result.ToString();
                        foundFrequency = true;
                        break;
                    }
                    else
                    {
                        calculatedFrequencies.Add(result);
                        frequency = result;
                    }
                }
            }

            Console.WriteLine($"The result for Day 1 pt. 2 is {output}");
        }

        private static IEnumerable<int> CalculateChangeSet()
        {
            foreach (var change in _input.Trim().Split("\n"))
            {
                int delta;
                Int32.TryParse(change, out delta);
                yield return delta;
            }
        }
    }
}
