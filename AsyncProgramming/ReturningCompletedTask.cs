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

    internal class ReturningExceptionTask()
    {
        static int result = 0;

        public static async Task<int> CallFunctionWithError()
        {
            try
            {
                result = await GetValueAsyncWithError();
            }
            catch (InvalidOperationException) 
            {
                Console.WriteLine("Hello world myMistake");
            }

            return result;
        }

        static async Task<int> GetValueAsyncWithError()
        {
            Console.WriteLine("Starting method with error...");
            await Task.Delay(100); // Simulate some delay

            throw new InvalidOperationException("Something went wrong within GetValueAsyncWithError!");

            // return Task.FromException<int>(new InvalidOperationException("Something went wrong"));
        }
    }
}
