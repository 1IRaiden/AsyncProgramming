using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    internal class TimeoutExample
    {
        public static async Task CallCheckTimeOut()
        {
            Console.WriteLine("Starting operation with timeout");
            try
            {
                string result = await PerformOperationWithTimeout(TimeSpan.FromSeconds(3));
                Console.WriteLine($"Operation successful result: {result}");
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine($"Operation timed out: {ex.Message}");
            }

            Console.WriteLine("Example completed.");
        }

        public static async Task<string> PerformOperationWithTimeout(TimeSpan timeout)
        {
            using (var cts = new System.Threading.CancellationTokenSource())
            {

                Task<string> operationTask = PerformLongOperation();
                Task delayTask = Task.Delay(timeout, cts.Token);

                Task completedTask = await Task.WhenAny(operationTask, delayTask);

                if (completedTask == operationTask)
                {
                    cts.Cancel();
                    return await operationTask;
                }
                else
                {
                    throw new TimeoutException("Operation timed out");
                }
            }
        }

        static async Task<string> PerformLongOperation()
        {
            Console.WriteLine("Starting long operation");
            await Task.Delay(5000); // Simulate long-running operation (5 seconds)
            Console.WriteLine("Long operation completed.");
            return "Operation Complete";
        }
    }
}
