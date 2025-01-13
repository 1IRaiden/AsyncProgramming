using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    internal class ProgressExample
    {
        public static async Task TestProgress()
        {
            // 1. Create an IProgress<int> instance to track progress updates.
            var progress = new Progress<int>(percent =>
            {
                Console.WriteLine($"Progress: {percent}%");
            });

            Console.WriteLine("Starting long operation with progress reporting...");
            await LongRunningOperationAsync(progress); // 2. Pass it to the async method
            Console.WriteLine("Long operation completed");

        }


        static async Task LongRunningOperationAsync(IProgress<int> progress)
        {
            for (int i = 0; i <= 100; i += 20)
            {
                await Task.Delay(500); // Simulate work.
                progress.Report(i); // 3. Report progress
            }
        }
    }
}

