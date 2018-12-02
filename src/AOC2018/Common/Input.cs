using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AOC2018.Common
{
    internal static class InputCollector
    {
        public static async Task<string> GetInputForDay(int day)
        {
            Console.WriteLine($"Fetching inputs for day {day}");
            var client = BuildClient();
            var result = await client.GetAsync($"https://adventofcode.com/2018/day/{day}/input");
            return await result.Content.ReadAsStringAsync();
        }

        private static HttpClient BuildClient()
        {
            var cookies = new CookieContainer();
            cookies.Add(new Cookie
            {
                Name = "session",
                Value = Environment.GetEnvironmentVariable("SESSION_ID"),
                Domain = "adventofcode.com"
            });

            var handler = new HttpClientHandler
            {
                CookieContainer = cookies
            };

            return new HttpClient(handler);
        }
    }
}
