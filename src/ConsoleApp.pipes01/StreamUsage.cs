using System;
using System.IO;
using System.Text;

namespace ConsoleApp.pipes01
{
    public static class StreamUsage
    {
        public static void WriteSomeData(Stream stream)
        {
            byte[] bytes = Encoding.ASCII.GetBytes("hello, world!");
            stream.Write(bytes, 0, bytes.Length);
            stream.Flush();
        }

        public static void ReadSomeData(Stream stream)
        {
            int bytesRead;
            // note that the caller usually can't know much about
            // the size; .Length is not usually usable
            byte[] buffer = new byte[256];
            do
            {
                bytesRead = stream.Read(buffer, 0, buffer.Length);
                if (bytesRead > 0)
                {   // note this only works for single-byte encodings
                    string s = Encoding.ASCII.GetString(
                        buffer, 0, bytesRead);
                    Console.Write(s);
                }
            } while (bytesRead > 0);
        }

        public static void Execute()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // write something
                WriteSomeData(ms);
                // rewind - MemoryStream works like a tape
                ms.Position = 0;
                // consume it
                ReadSomeData(ms);
            }
            Console.WriteLine("");
        }

    }
}
