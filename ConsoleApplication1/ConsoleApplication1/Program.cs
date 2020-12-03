using System;
using ClassLibrary1;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string label = "A quick brown fox jumps over the lazy dog";
            string seed = "12098764573927839273337249";
            int size = 60;

            MAC mac = new MAC();

            mac.Label = label;
            mac.Seed = seed;
            mac.Size = size;

            mac.doPRF();

            Console.WriteLine("Output from PRF HMAC:");
            Console.WriteLine(BitConverter.ToString(mac.Buffer));
            Console.WriteLine();
            Console.WriteLine("Length:" + mac.Buffer.Length);
        }
    }
}
