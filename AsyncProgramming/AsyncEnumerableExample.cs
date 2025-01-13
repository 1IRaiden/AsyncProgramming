using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    public class AsyncEnumerableExample
    {
        public static async IAsyncEnumerable<int> GenerateNumbersAsync(int count)
        {
            for (int i = 0; i < count; i++)
            {
                await Task.Delay(100); // Simulate some delay
                yield return i;
            }
        }

        public static async Task StartAsyncEnumerable()
        {
            Console.WriteLine("Starting asynchronous enumeration...");
            await foreach (int number in GenerateNumbersAsync(5))
            {
                Console.WriteLine($"Number: {number}");
            }
            Console.WriteLine("Enumeration completed.");
        }
    }
}
