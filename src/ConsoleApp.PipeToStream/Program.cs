using System;
using System.Threading.Tasks;

namespace ConsoleApp.PipeToStream
{
    class Program
    {
        /// <summary>
        /// <see href="https://blog.marcgravell.com/2018/07/pipe-dreams-part-2.html">Original Article</see>
        /// </summary>
        static Task Main(string[] args)
        {
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
    }
}
