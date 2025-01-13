using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    public class WaitAllExample
    {
        public static async Task WaitingTasks()
        {
            Console.WriteLine("Starting group of tasks...");
            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Delay(2000));
            tasks.Add(Task.Delay(1000));
            tasks.Add(Task.Delay(3000));

            await Task.WhenAll(tasks); // Wait for all tasks to complete
            Console.WriteLine("All tasks completed.");

            // With results
            List<Task<int>> tasksWithResult = new List<Task<int>>();
            tasksWithResult.Add(LongRunningOperation(2, 2000));
            tasksWithResult.Add(LongRunningOperation(4, 1000));
            tasksWithResult.Add(LongRunningOperation(6, 3000));

            var results = await Task.WhenAll(tasksWithResult); // Wait for all, get results
            Console.WriteLine($"Task with results: {string.Join(", ", results)}");
        }

        static async Task<int> LongRunningOperation(int value, int delay)
        {
            await Task.Delay(delay);
            return value * 2;
        }
    }

}
