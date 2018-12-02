using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AOC2018.Common;

namespace AOC2018.Days
{
    public static class Day2
    {
        private static readonly string _input;

        static Day2()
        {
            var task = InputCollector.GetInputForDay(2);
            task.Wait();
            _input = task.Result.Trim();
        }

        public static void Run()
        {
            var ids = _input.Split("\n")
                .Select(str =>
                {
                    return str
                        .GroupBy(c => c)
                        .Select(c => new
                        {
                            Char = c.Key,
                            Count = c.Count()
                        });
                });

            var twos = ids.Count(grouping => grouping.Any(c => c.Count == 2));
            var threes = ids.Count(grouping => grouping.Any(c => c.Count == 3));

            Console.WriteLine($"The result for Day 2 is {twos * threes}");
        }

        public static void RunPartTwo()
        {
            var ids = _input.Split('\n');
            var longest = ids.AsParallel()
                .Select(id =>
                {
                    return ids.AsParallel()
                        .Select(inner =>
                        {
                            if (id == inner) return "";

                            var sb = new StringBuilder(id.Length);
                            for (var i = 0; i < id.Length; i++)
                            {
                                if (id[i] == inner[i]) sb.Append(id[i]);
                            }

                            return sb.ToString();
                        })
                        .OrderByDescending(s => s.Length)
                        .First();
                })
                .OrderByDescending(s => s.Length)
                .First();

            Console.WriteLine($"The result for Day 2 pt. 2 is {longest}");
        }
    }
}
