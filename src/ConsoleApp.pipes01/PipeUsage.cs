using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.pipes01
{
    public static class PipeUsage
    {
        public static async ValueTask WriteSomeDataAsync(PipeWriter writer)
        {
            // use an oversized size guess
            Memory<byte> workspace = writer.GetMemory(20);
            // write the data to the workspace
            int bytes = Encoding.ASCII.GetBytes(
                "hello, world!", workspace.Span);
            // tell the pipe how much of the workspace
            // we actually want to commit
            writer.Advance(bytes);
            // this is **not** the same as Stream.Flush!
            await writer.FlushAsync();
        }

        public static async ValueTask ReadSomeDataAsync(PipeReader reader)
        {
            while (true)
            {
                // await some data being available
                ReadResult read = await reader.ReadAsync();
                ReadOnlySequence<byte> buffer = read.Buffer;
                // check whether we've reached the end
                // and processed everything
                if (buffer.IsEmpty && read.IsCompleted)
                    break; // exit loop

                // process what we received
                foreach (ReadOnlyMemory<byte> segment in buffer)
                {
                    string s = Encoding.ASCII.GetString(
                        segment.Span);
                    Console.Write(s);
                }
                // tell the pipe that we used everything
                reader.AdvanceTo(buffer.End);
            }
        }

        public static async Task ExecuteAsync()
        {
            Pipe pipe = new Pipe();
            // write something
            await WriteSomeDataAsync(pipe.Writer);
            // signal that there won't be anything else written
            pipe.Writer.Complete();
            // consume it
            await ReadSomeDataAsync(pipe.Reader);
            Console.WriteLine("");
        }
    }
}
