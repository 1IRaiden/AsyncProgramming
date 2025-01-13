using System;

namespace AsyncProgramming
{
    public class TaskDelayExample
    {
        static async Task<int> GetValueAfterDelay(int delayMilliseconds, int value)
        {
            await Task.Delay(delayMilliseconds);
            return value+1; // Return the value after the delay is complete.
        }

        public static async Task CallTask()
        {
            Console.WriteLine("Starting delay and value creation...");
            int result = await GetValueAfterDelay(2000, 42);
            Console.WriteLine($"Value obtained after delay: {result}");
        }
    }


    internal class Programm
    {
        static async Task Main(string[] args)
        {
            await AsyncEnumerableExample.StartAsyncEnumerable();
            // await ProgressExample.TestProgress();
            // await ReturningExceptionTask.CallFunctionWithError();
            // await ReturningCompletedTask.CallCompletedTaskMethod();
            // await TimeoutExample.CallCheckTimeOut();
            // await TaskDelayExample.CallTask();
        }
    }
}