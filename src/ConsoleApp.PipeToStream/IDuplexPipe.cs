using System.IO.Pipelines;

namespace ConsoleApp.PipeToStream
{
    public interface IDuplexPipe
    {
        PipeReader Input { get; }
        PipeWriter Output { get; }
    }
}
