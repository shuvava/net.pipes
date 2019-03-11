using System;
using System.Threading.Tasks;

namespace ConsoleApp.pipes01
{
    class Program
    {
        /// <summary>
        /// <see href="https://blog.marcgravell.com/2018/07/pipe-dreams-part-1.html">Original Article</see>
        /// </summary>
        static async Task Main(string[] args)
        {
            Console.WriteLine("Stream usage");
            StreamUsage.Execute();
            Console.WriteLine("Pipe usage");
            await PipeUsage.ExecuteAsync();
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
    }
}
