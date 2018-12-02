using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AOC2018.Days;
using dotenv.net;

namespace AOC2018
{
    class Program
    {
        static async Task Main(string[] args)
        {
            #if DEBUG
            DotEnv.Config();
            #endif

            Console.WriteLine("Enter the day to run:");
            string input;
            bool validInput;
            int day;

            do {
                input = Console.ReadLine();
                validInput = Int32.TryParse(input, out day);
                if (!validInput)
                {
                    Console.WriteLine($"Sorry, {input} is not a valid numeric day.");
                }
            } while (!validInput);

            Console.WriteLine($"Calculating results for day {day}...");
            await HandleDay(day);
        }

        public static Task HandleDay(int day)
        {
            switch(day)
            {
                default:
                    return Task.CompletedTask;
                case 1:
                    return Task.WhenAll(
                        Task.Run(() => Day1.Run()),
                        Task.Run(() => Day1.RunPartTwo())
                    );
                case 2:
                    return Task.WhenAll(
                        Task.Run(() => Day2.Run()),
                        Task.Run(() => Day2.RunPartTwo())
                    );
            }
        }
    }
}
