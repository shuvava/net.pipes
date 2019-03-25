using System.IO;
using System.IO.Pipelines;

namespace ConsoleApp.PipeToStream
{
    public class StreamDuplexPipe : IDuplexPipe
    {
        Stream _stream;
        Pipe _readPipe, _writePipe;

        public PipeReader Input => _readPipe.Reader;
        public PipeWriter Output => _writePipe.Writer;
    }
}
