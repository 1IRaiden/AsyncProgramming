using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    internal class ReturningCompletedTask
    {
        public static async Task CallNotAstncMethod()
        {
            int result = await GetValueFromMethod();
            Console.WriteLine($"Result: {result}");
        }
        public static async Task CallCompletedTaskMethod()
        {
            await DoTask();
        }

        public static Task DoTask()
        {
            return Task.CompletedTask;
        }

        public static async Task<int> GetValueFromMethod()
        {
            // This is a synchronous method
            int value = GetValue();
            return await Task.FromResult(value); // Wrap the result in a Task
        }


        private static int GetValue()
        {
            return 42;
        }
    }
}
